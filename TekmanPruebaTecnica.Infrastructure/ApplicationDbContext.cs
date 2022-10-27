using Microsoft.EntityFrameworkCore;
using TekmanPruebaTecnica.Domain.Entities;

namespace TekmanPruebaTecnica.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<Exercice> Exercices { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<NumericQuestion> NumericQuestions { get; set; }
    public DbSet<StringQuestion> StringQuestions { get; set; }
    public DbSet<UserNote> UserNotes { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public void SeedDataBase()
    {
        var users = new List<User>()
        {
            new User()
            {
                Name = "Pol",
                LastName = "Caralps Fontrubí"
            }
        };

        Users.AddRange(users);

        var activities = new List<Activity>()
        {
            //MATHS
            new Activity()
            {
                Title = "Maths Activity 01",
                Course = ActivityCourse.Maths,
                Type = ActivityType.Activity,
                Exercices = new List<Exercice>()
                {
                    new Exercice()
                    {
                        Title = "Sum",
                        Questions = new List<Question>()
                        {
                            new NumericQuestion() { Title = "2 + 2", CorrectAnswer = 4 },
                            new NumericQuestion() { Title = "8 + 8", CorrectAnswer = 16 }
                        }
                    },
                    new Exercice()
                    {
                        Title = "Substraction",
                        Questions = new List<Question>()
                        {
                            new NumericQuestion() { Title = "8 - 3", CorrectAnswer = 5 },
                            new NumericQuestion() { Title = "28 - 8", CorrectAnswer = 20 }
                        }
                    }
                }
            },
            new Activity()
            {
                Title = "Maths Activity 02",
                Course = ActivityCourse.Maths,
                Type = ActivityType.Exercice,
                Exercices = new List<Exercice>()
                {
                    new Exercice()
                    {
                        Title = "Multiplication",
                        Questions = new List<Question>()
                        {
                            new NumericQuestion() { Title = "5 * 5", CorrectAnswer = 25 },
                            new NumericQuestion() { Title = "10 * 10", CorrectAnswer = 100 }
                        }
                    },
                    new Exercice()
                    {
                        Title = "Division",
                        Questions = new List<Question>()
                        {
                            new NumericQuestion() { Title = "10 / 2", CorrectAnswer = 5 },
                            new NumericQuestion() { Title = "36 / 6", CorrectAnswer = 6 }
                        }
                    }
                }
            },
            new Activity()
            {
                Title = "Maths Activity 03",
                Course = ActivityCourse.Maths,
                Type = ActivityType.SelfEvaluation,
                Exercices = new List<Exercice>()
                {
                    new Exercice()
                    {
                        Title = "Calculate these operations",
                        Questions = new List<Question>()
                        {
                            new NumericQuestion() { Title = "10 + 10 * 2", CorrectAnswer = 30 },
                            new NumericQuestion() { Title = "8 + 8 - 5 * 2", CorrectAnswer = 6 }
                        }
                    }
                }
            },
            new Activity()
            {
                Title = "Maths Activity 04",
                Course = ActivityCourse.Maths,
                Type = ActivityType.Test,
                Exercices = new List<Exercice>()
                {
                    new Exercice()
                    {
                        Title = "Answer correctly",
                        Questions = new List<Question>()
                        {
                            new NumericQuestion() { Title = "20 + 4 * 2 - 10", CorrectAnswer = 18 },
                            new NumericQuestion() { Title = "25 / 5 + 4", CorrectAnswer = 9 },
                            new NumericQuestion() { Title = "5 * 5 * 4", CorrectAnswer = 100 },
                            new NumericQuestion() { Title = "10 / 2 + 5 * 4", CorrectAnswer = 25 }
                        }
                    }
                }
            },
        };

        Activities.AddRange(activities);

        var userNotes = new List<UserNote>()
        {
            new UserNote()
            {
                UserId = 1,
                QuestionId = 1,
                Note = 1,
                Answer = "4"
            },
            new UserNote()
            {
                UserId = 1,
                QuestionId = 2,
                Note = 1,
                Answer = "16"
            },
            new UserNote()
            {
                UserId = 1,
                QuestionId = 3,
                Note = 1,
                Answer = "5"
            },
            new UserNote()
            {
                UserId = 1,
                QuestionId = 4,
                Note = 1,
                Answer = "20"
            },
            new UserNote()
            {
                UserId = 1,
                QuestionId = 5,
                Note = 1,
                Answer = "25"
            },
            new UserNote()
            {
                UserId = 1,
                QuestionId = 6,
                Note = 1,
                Answer = "100"
            },
            new UserNote()
            {
                UserId = 1,
                QuestionId = 7,
                Note = 1,
                Answer = "5"
            },
            new UserNote()
            {
                UserId = 1,
                QuestionId = 8,
                Note = 1,
                Answer = "6"
            },
            new UserNote()
            {
                UserId = 1,
                QuestionId = 9,
                Note = 1,
                Answer = "30"
            },
            new UserNote()
            {
                UserId = 1,
                QuestionId = 10,
                Note = 1,
                Answer = "6"
            },
            new UserNote()
            {
                UserId = 1,
                QuestionId = 11,
                Note = 1,
                Answer = "18"
            },
            new UserNote()
            {
                UserId = 1,
                QuestionId = 12,
                Note = 1,
                Answer = "9"
            },
            new UserNote()
            {
                UserId = 1,
                QuestionId = 13,
                Note = 1,
                Answer = "100"
            },
            new UserNote()
            {
                UserId = 1,
                QuestionId = 14,
                Note = 1,
                Answer = "25"
            },

        };

        UserNotes.AddRange(userNotes);

        this.SaveChanges();
    }
}
