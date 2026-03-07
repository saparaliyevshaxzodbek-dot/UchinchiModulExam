namespace ExamProject.Dtos;

public class QuestionGetDto
{
    public string Text { get; set; }
    public string VariantA { get; set; }
    public string VariantB { get; set; }
    public string VariantC { get; set; }
    public Guid QuestionId { get; internal set; }
}
