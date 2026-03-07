namespace ExamProject.Servises;
using ExamProject.Dtos;
using ExamProject.Models;


public interface IQuestionService
{
    public Guid AddQuestion(QuestionCreateDto questionCreateDto);
    public bool RemoveQuestion(Guid questionId);
    public (bool isCorrect, string correctAnswer) SolveQuestion(Guid questionId, string answer);
    public int GetCountOfQuestions();
    public QuestionGetDto GetRandomQuestion();
}