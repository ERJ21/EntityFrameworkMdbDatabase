namespace DelayTracker.v2_1
{
    public class Projects
    {
        public int ProjectId { get; set; }
        public string ProjectNumber { get; set; }
        public string ProjectName { get; set; }
        public string Location { get; set; }
        public string ProjectDescription { get; set; }
        public bool? ProjectIsActive { get; set; }
        public int Vessel { get; set; }
    }
}
