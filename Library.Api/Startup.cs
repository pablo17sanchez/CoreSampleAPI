using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Api.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Library.Api.Services;
using System.Xml.Linq;
using System.Xml;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Library.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

           

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(sepup=> {
                sepup.ReturnHttpNotAcceptable = true;
                sepup.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
                sepup.InputFormatters.Add(new XmlDataContractSerializerInputFormatter());

            });

            var conectionstring = Configuration["connectionStrings:libraryDBConnectionString"];
            services.AddDbContext<LibraryContext>(o => o.UseSqlServer(conectionstring));


            services.AddScoped<ILibraryRepository, LibraryRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerfactory)
        {

            loggerfactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else {

                app.UseExceptionHandler();

                

            }


            // libraryContext.EnsureSeedDataForContext();
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Entities.Author, Models.AuthorsDTO>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}")).ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.Year));

                cfg.CreateMap<Entities.Books, Models.AuthorsDTO>();
               
               cfg.CreateMap<Models.AuthorForCreationDto, Entities.Author>().ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName)).ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName)).ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre));
                cfg.CreateMap<Models.BooksForCreationDto, Entities.Books>();

                cfg.CreateMap<Models.BookForUpdateDto, Entities.Books>();
            });

            

            app.UseMvc();
        }
    }
}
