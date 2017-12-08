using System.Collections.Generic;
using Board.Data.Models;

namespace Board.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Board.Data.BoardContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Board.Data.BoardContext context)
        {
            CreateDefaultChannels(context);
            CreateAdminAccount(context);
        }

        private void CreateDefaultChannels(Board.Data.BoardContext context)
        {
            context.Channels.AddOrUpdate(
                // EDIT THIS DATA
                    new Channel()
                    {
                        Id = 1,
                        Title = "General",
                        Rules = "Rules"
                    }
                );
        }

        private void CreateAdminAccount(BoardContext context)
        {
            context.Administrators.AddOrUpdate(
                new Administrator()
                {
                    Id = 1,
                    User = new User()
                    {
                        // EDIT THIS DATA
                        Id = 1,
                        BirthDate = new DateTime(1990, 1, 1),
                        EMail = "Admin@dotcerberus.com",
                        Gender = "Nondescript",
                        Name = "AdminNAME",
                        Surname = "AdminSURNAME",
                        Password = "!!92456-DEFAULT-ADMIN-25734!!",
                        Username = "Admin-CERBERUS",
                        Screenname = "DEFAULT-ADMINISTRATOR",
                    }
                });
        }
    }
}
