using ImdbData.Contexts;
using ImdbData.Models;
using ImdbData.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImdbData.UnitOfWork
{
    
        public class UnitOfWork : IDisposable
        {
            private ImdbContext context = new ImdbContext();

                 private BaseRepository<Movie> movieRepository;
                 private BaseRepository<Cast> castRepository;
                 private BaseRepository<CastRole> castRoleRepository;
                 private BaseRepository<MovieCastRoleMapping> movieCastRoleRepository;

        private delegate void SetParameterValueDelegate(string test);
        private SetParameterValueDelegate SetParameterValueCallback = Method;
        private static void Method(string a) { Console.WriteLine(a); }

       

        public BaseRepository<Movie> MovieRepository
        {
            get
            {

                if (this.movieRepository == null)
                {
                    this.movieRepository = new BaseRepository<Movie>(context);
                }
                return movieRepository;
            }
            
        }
        public BaseRepository<Cast> CastRepository
        {
            get
            {

                if (this.castRepository == null)
                {
                    this.castRepository = new BaseRepository<Cast>(context);
                }
                return castRepository;
            }
        }
        public BaseRepository<CastRole> CastRoleRepository
        {
            get
            {

                if (this.castRoleRepository == null)
                {
                    this.castRoleRepository = new BaseRepository<CastRole>(context);
                }
                return castRoleRepository;
            }
        }
        public BaseRepository<MovieCastRoleMapping> MovieCastRoleMappingRepository
        {
            get
            {

                if (this.movieCastRoleRepository == null)
                {
                    this.movieCastRoleRepository = new BaseRepository<MovieCastRoleMapping>(context);
                }
                return movieCastRoleRepository;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            var entry = context.ChangeTracker.Entries();
            foreach (var item in entry)
            {
                SetParameterValueCallback.Invoke(item.State.ToString());        
            }
            context.SaveChanges();
        }
    }
    }

