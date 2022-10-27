using System.Diagnostics;
using TekmanPruebaTecnica.Application.Interfaces;
using TekmanPruebaTecnica.Application.Interfaces.Repositories;
using TekmanPruebaTecnica.Domain.Entities;

namespace TekmanPruebaTecnica.Application.Services;

public class AnswerService : IAnswerService
{
    private readonly IUserRepository _userRepository;
    private readonly IActivityRepository _activityRepository;
    private readonly IUserNoteRepository _userNoteRepository;
    
    public AnswerService(IUserRepository userRepository,
        IActivityRepository activityRepository,
        IUserNoteRepository userNoteRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(IUserRepository));
        _activityRepository = activityRepository ?? throw new ArgumentNullException(nameof(IActivityRepository));
        _userNoteRepository = userNoteRepository ?? throw new ArgumentNullException(nameof(IUserNoteRepository));
    }

    public async Task<decimal> AnswerQuestionAsync(int userId, int questionId, string answer)
    {
        //var user = await _userRepository.GetAsync(userId);

        var user = await _userRepository.GetWithNotesAsync(userId);

        if (user is null)
        {
            throw new Exception("User not found!");
        }

        var activity = await _activityRepository.GetByQuestionIdAsync(questionId);

        if (activity is null)
        {
            throw new Exception("Activity not found!");
        }

        var questionNote = activity.AnswerQuestion(questionId, answer);

        var userNote = user.Notes.SingleOrDefault(n => n.QuestionId == questionId);

        if (userNote is null)
        {
            await CreateUserNoteAsync(userId, questionId, answer, questionNote);
        }
        else 
        {
            userNote.Update(answer: answer, note: questionNote);
        }

        await _userNoteRepository.SaveChangesAsync();

        return questionNote;
    }

    public async Task<decimal> AnswerActivityAsync(int userId, int activityId, Dictionary<int, string> answerQuestions)
    {
        var user = await _userRepository.GetAsync(userId);

        if (user is null)
        {
            throw new Exception("User not found!");
        }

        var activity = await _activityRepository.GetAsync(activityId);

        if (activity is null)
        {
            throw new Exception("Activity not found!");
        }

        decimal note = 0;

        foreach (var question in answerQuestions)
        {
            var questionNote = activity.AnswerQuestion(question.Key, question.Value);

            await CreateUserNoteAsync(userId, question.Key, question.Value, questionNote);

            note += questionNote;
        }

        var noteActivity = (note * 10) / answerQuestions.Count();

        await _userNoteRepository.SaveChangesAsync();

        return noteActivity;
    }

    private async Task CreateUserNoteAsync(int userId, int questionId, string answer, decimal note)
    {
        var userNote = UserNote.Create(
            userId: userId,
            questionId: questionId,
            answer: answer,
            note: note);

        await _userNoteRepository.AddAsync(userNote);
    }

    public async Task<IEnumerable<UserNote>> GetUserNotesAsync(int userId)
    {
        return await _userNoteRepository.GetUserNotesAsync(userId);
    }
}
