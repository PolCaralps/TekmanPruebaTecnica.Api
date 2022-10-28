using TekmanPruebaTecnica.Application.Interfaces;
using TekmanPruebaTecnica.Application.Interfaces.Repositories;
using TekmanPruebaTecnica.Domain.Entities;

namespace TekmanPruebaTecnica.Application.Services;

public class NoteService : INoteService
{
    private readonly AppSettings _appSettings;
    private readonly IUserRepository _userRepository;
    private readonly IActivityRepository _activityRepository;
    private readonly IUserNoteRepository _userNoteRepository;
    public NoteService(AppSettings appSettings,
        IUserRepository userRepository,
        IActivityRepository activityRepository,
        IUserNoteRepository userNoteRepository)
    {
        _appSettings = appSettings;
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(IUserRepository));
        _activityRepository = activityRepository ?? throw new ArgumentNullException(nameof(IActivityRepository));
        _userNoteRepository = userNoteRepository ?? throw new ArgumentNullException(nameof(IUserNoteRepository));
    }

    public async Task<decimal> GetNoteActivityAsync(int userId, int activityId) 
    {
        var user = await _userRepository.GetWithNotesAsync(userId);

        if (user is null)
        {
            throw new Exception("User not found!");
        }

        var activity = await _activityRepository.GetAsync(activityId);

        if (activity is null)
        {
            throw new Exception("Activity not found!");
        }

        var activityNotes = user.Notes.Where(un => un.Question?.Exercice?.ActivityId == activityId);

        decimal finalNote = (activityNotes.Sum(n => n.Note) * 10) / activityNotes.Count();

        return finalNote;
    }

    public async Task<decimal> GetNoteByCourse(int userId, ActivityCourse course)
    {
        var user = await _userRepository.GetWithNotesAsync(userId);

        if (user is null)
        {
            throw new Exception("User not found!");
        }

        var noteCourse = GetCourseNote(user, course);

        return noteCourse;
    }

    public async Task<decimal> GetFinalYearNote(int userId) 
    {
        var user = await _userRepository.GetWithNotesAsync(userId);

        if (user is null)
        {
            throw new Exception("User not found!");
        }

        var userNotesMath = GetCourseNote(user, ActivityCourse.Maths);
        var userNotesDitital = GetCourseNote(user, ActivityCourse.Digital);
        var userNotesSocial = GetCourseNote(user, ActivityCourse.Social);

        var mathNote = GetGlobalNote(ActivityCourse.Maths, userNotesMath);
        var dititalNote = GetGlobalNote(ActivityCourse.Digital, userNotesDitital);
        var socialNote = GetGlobalNote(ActivityCourse.Social, userNotesSocial);

        return mathNote + dititalNote + socialNote;
    }

    private decimal GetCourseNote(User user, ActivityCourse activityCourse)
    {
        var courseNotes = user.Notes.Where(un => un.Question?.Exercice?.Activity?.Course == activityCourse);

        var activity = courseNotes.Where(un => un.Question?.Exercice?.Activity?.Type == ActivityType.Activity);
        var exercice = courseNotes.Where(un => un.Question?.Exercice?.Activity?.Type == ActivityType.Exercice);
        var selfAvaluation = courseNotes.Where(un => un.Question?.Exercice?.Activity?.Type == ActivityType.SelfEvaluation);
        var test = courseNotes.Where(un => un.Question?.Exercice?.Activity?.Type == ActivityType.Test);


        decimal activityNote = 0;
        decimal exerciceNote = 0;
        decimal selfAvaluationNote = 0;
        decimal testNote = 0;


        if (activity.Count() > 0) 
        {
            activityNote = ((activity.Sum(n => n.Note) * 10) / activity.Count()) * _appSettings.PercentageActivity;
        }

        if (exercice.Count() > 0)
        {
            exerciceNote = ((exercice.Sum(n => n.Note) * 10) / exercice.Count()) * _appSettings.PercentatgeExercice;
        }

        if (selfAvaluation.Count() > 0)
        {
            selfAvaluationNote = ((selfAvaluation.Sum(n => n.Note) * 10) / selfAvaluation.Count()) * _appSettings.PercentatgeSelfEvaluation;
        }

        if (test.Count() > 0)
        {
            testNote = ((test.Sum(n => n.Note) * 10) / test.Count()) * _appSettings.PercentatgeTest;
        }

        return activityNote + exerciceNote + selfAvaluationNote + testNote;
    }

    private decimal GetGlobalNote(ActivityCourse activityCourse, decimal note)
    {
        switch (activityCourse)
        {
            case ActivityCourse.Social:
                return note * _appSettings.PercentageSocial;
                break;
            case ActivityCourse.Digital:
                return note * _appSettings.PercentatgeDigital;
                break;
            case ActivityCourse.Maths:
                return note * _appSettings.PercentatgeMaths;
                break;
            default:
                throw new Exception("This course not exist");
        }
    }
}
