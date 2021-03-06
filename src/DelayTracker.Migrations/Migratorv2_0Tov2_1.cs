﻿using System.Linq;

namespace DelayTracker.Migrations
{
    public class Migratorv2_0Tov2_1
    {
        public void Migrate(v2_0.ModelContext v2_0Context, v2_1.ModelContext v2_1Context)
        {
            MigrateProjects(v2_0Context, v2_1Context);

            //TODO: Migrate other tables
        }

        public void MigrateProjects(v2_0.ModelContext v2_0Context, v2_1.ModelContext v2_1Context)
        {
            //TODO: Handle duplicates and conflicts properly. I just ignored those here for demonstration purposes.

            v2_1Context.Projects.AddRange(
                v2_0Context.Projects
                .Select(v2_0project => new v2_1.Projects
                {
                    ProjectNumber = v2_0project.ProjectNumber,
                    ProjectName = v2_0project.ProjectName,
                    Location = v2_0project.Location,
                    ProjectDescription = v2_0project.ProjectDescription,
                    ProjectIsActive = v2_0project.ProjectIsActive,
                    Vessel = v2_0project.Vessel
                }));
        }
    }
}