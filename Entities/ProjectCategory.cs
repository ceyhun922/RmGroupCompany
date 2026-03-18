namespace RmWebApi.Entities
{
    public class ProjectCategory
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ColorCode { get; set; }
    public List<Project> Projects { get; set; }
}

}