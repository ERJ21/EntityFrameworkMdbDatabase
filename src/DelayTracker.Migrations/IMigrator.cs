namespace DelayTracker.Migrations
{
    public interface IMigrator
    {
        /// <summary>
        /// Migrates any version of the delay tracker database to the latest version.
        /// </summary>
        /// <param name="toMigrateFilePath">The file path of the delay tracker database to migrate.</param>
        /// <param name="migratedFilePath">The file path of the delay tracker database migrated to the latest version.</param>
        void Migrate(string toMigrateFilePath, string migratedFilePath);
    }
}
