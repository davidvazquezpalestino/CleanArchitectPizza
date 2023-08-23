﻿using Membership.Entities.Options;

namespace BlazingPizza.WebApi.Configurations;
internal static class ServicesConfiguration
{
    public static WebApplication ConfigureWebApiServices(
        this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("BearerToken",
                new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Proporciona el valor del token",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });

            options.AddSecurityRequirement(
                new OpenApiSecurityRequirement
                {
                    { 
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "BearerToken"
                            }
                        },
                        new string[]{ }                 
                    }
                });
        });


        builder.Services.Configure<SpecialsOptions>(
            builder.Configuration.GetSection(
                SpecialsOptions.SectionKey));

        builder.Services.Configure<ConnectionStringsOptions>(
            builder.Configuration.GetSection(
                ConnectionStringsOptions.SectionKey));

        builder.Services.Configure<ASPNETIdentityOptions>(
            builder.Configuration.GetSection(
                ASPNETIdentityOptions.SectionKey));

        var JwtConfigurationOptionsSection =
            builder.Configuration.GetSection(
                JwtConfigurationOptions.SectionKey);
        builder.Services.Configure<JwtConfigurationOptions>(
            JwtConfigurationOptionsSection);

        builder.Services.AddBlazingPizzaBackendServices();

        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
            });
        });

        builder.Services.AddAuthentication(
            JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                JwtConfigurationOptionsSection.Bind(
                    options.TokenValidationParameters);

                options.TokenValidationParameters
                .IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(
                        JwtConfigurationOptionsSection["securitykey"]));

                if (int.TryParse(
                    JwtConfigurationOptionsSection["ClockSkewInMinutes"],
                    out int Value))
                {
                    options.TokenValidationParameters
                    .ClockSkew = TimeSpan.FromMinutes(Value);
                }
            });

        builder.Services.AddAuthorization();

        return builder.Build();
    }
}
