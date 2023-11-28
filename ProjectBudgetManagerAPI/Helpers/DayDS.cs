namespace ProjectBudgetManagerAPI.Helpers
{
    public class DayDS
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public List<ProjectDS>? NormalProjects { get; set; }
        public List<ProjectDS>? SpecialProjects { get; set; }
    }
}
