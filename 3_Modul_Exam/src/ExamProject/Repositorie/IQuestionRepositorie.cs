using ExamProject.Models;

namespace ExamProject.Repositorie;

public interface IQuestionRepositorie
{
    public List<Question>? GetAllQuestions();
    public void SaveAllQuestions(List<Question> questions);
}