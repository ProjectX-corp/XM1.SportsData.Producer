﻿using Amazon.Runtime;
using Amazon.SecretsManager;
using LocalStack.Client.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using XM1.SportsData.Producer.Application.Interface;
using XM1.SportsData.Producer.Infrastructure.Configurations;

namespace XM1.SportsData.Producer.API.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // Use LocalStack for development
                services.AddLocalStack(configuration);
                services.AddSingleton<IAmazonSecretsManager>(sp =>
                {
                    var localStackUrl = "https://localhost.localstack.cloud:4566";
                    var clientConfig = new AmazonSecretsManagerConfig
                    {
                        ServiceURL = localStackUrl,
                        UseHttp = true,
                        AuthenticationRegion = "us-east-2"
                    };
                    var awsCredentials = new BasicAWSCredentials("test", "test");
                    return new AmazonSecretsManagerClient(awsCredentials, clientConfig);
                });
            }
            else
            {
                // Use real AWS services for production
                services.AddAWSService<IAmazonSecretsManager>(configuration.GetAWSOptions());
            }

            // Configuration
            services.AddSingleton<ISecretsManager, SecretsManager>();

            // Database
            var secretsManager = services.BuildServiceProvider().GetRequiredService<ISecretsManager>();
            var connectionString = secretsManager.GetConnectionString("DbSecret");

            services.AddDbContext<DataContext>((serviceProvider, options) =>
            {
                options.UseMySQL(
                     "Server=localhost;Port=3306;Database=xmatch;User ID=root;Password=Aabb1010..",
                     b => b.MigrationsAssembly("XM1.SportsData.Producer.Infrastructure")
                 );
            });

            services.AddTransient<IDesignTimeDbContextFactory<DataContext>, DesignTimeDbContextFactory>();

            return services;
        }
    }
}
