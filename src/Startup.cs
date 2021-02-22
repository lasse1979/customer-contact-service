using CustomerContact.Api;
using CustomerContact.Api.Types;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CustomerContact
{
  public class Startup
  {
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddSingleton<CustomerContactData>();
      services.AddSingleton<CustomerContactQuery>();
      services.AddSingleton<CustomerContactMutation>();
      services.AddSingleton<CustomerContactInfoType>();
      services.AddSingleton<CustomerContactInfoInputType>();
      services.AddSingleton<ISchema, CustomerContactSchema>();

      services.AddLogging(builder => builder.AddConsole());
      services.AddHttpContextAccessor();

      services.AddGraphQL(options =>
      {
        options.EnableMetrics = true;
      })
      .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true)
      .AddSystemTextJson()
      .AddUserContextBuilder(httpContext => new GraphQLUserContext { User = httpContext.User });

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      // add http for Schema at default url /graphql
      app.UseGraphQL<ISchema>();

      // use graphql-playground at default url /ui/playground
      app.UseGraphQLPlayground();
    }
  }
}
