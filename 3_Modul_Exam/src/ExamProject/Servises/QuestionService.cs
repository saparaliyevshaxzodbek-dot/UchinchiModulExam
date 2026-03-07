using ExamProject.Dtos;
using ExamProject.Models;
using ExamProject.Repositorie;

namespace ExamProject.Servises;

public class QuestionService : IQuestionService
{
    private readonly IQuestionRepositorie QuestionRepositorie;

    public QuestionService()
    {
        QuestionRepositorie = new QuestionRepositorie();
    }



    public Guid AddQuestion(QuestionCreateDto questionCreateDto)
    {
        var question = new Question()
        {
            Text = questionCreateDto.Text,
            QuestionId = questionCreateDto.QuestionId,
            VariantA = questionCreateDto.VariantA,
            VariantB = questionCreateDto.VariantB,
            VariantC = questionCreateDto.VariantC,
            Answer = questionCreateDto.Answer,
        };

        var questions = QuestionRepositorie.GetAllQuestions();

        questions.Add(question);

        QuestionRepositorie.SaveAllQuestions(questions);

        return question.QuestionId;


    }

    public int GetCountOfQuestions()
    {
        var questions = QuestionRepositorie.GetAllQuestions();
        return questions.Count;
    }

    public QuestionGetDto GetRandomQuestion()
    {
        var questions = QuestionRepositorie.GetAllQuestions();

        if (questions.Count == 0) return null;

        Random random = new Random();
        int randomIndex = random.Next(0, questions.Count);
        var question = questions[randomIndex];

        return new QuestionGetDto()
        {
            QuestionId = question.QuestionId,
            Text = question.Text,
            VariantA = question.VariantA,
            VariantB = question.VariantB,
            VariantC = question.VariantC
        };
    }

    public bool RemoveQuestion(Guid questionId)
    {
        var questions = QuestionRepositorie.GetAllQuestions();

        var questionToRemove = questions.FirstOrDefault(q => q.QuestionId == questionId);

        if (questionToRemove == null) return false;

        questions.Remove(questionToRemove);
        QuestionRepositorie.SaveAllQuestions(questions);

        return true;
    }

    public (bool isCorrect, string correctAnswer) SolveQuestion(Guid questionId, string answer)
    {
        var questions = QuestionRepositorie.GetAllQuestions();

        var question = questions.FirstOrDefault(q => q.QuestionId == questionId);

        if (question == null) return (false, "Savol topilmadi");

        bool isCorrect = string.Equals(question.Answer, answer, StringComparison.OrdinalIgnoreCase);

        return (isCorrect, question.Answer);
    }






}
