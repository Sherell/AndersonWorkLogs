using System.Data.Entity;


namespace AndersonWorkLogsContext
{
    public class DBInitializer : CreateDatabaseIfNotExists<Context>
    {
        public DBInitializer()
        {
        }
        protected override void Seed(Context context)
        {
            base.Seed(context);
        }
    }
}
