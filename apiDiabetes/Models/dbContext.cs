using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace apiDiabetes.Models
{
    public partial class dbDiabetesContext : DbContext
    {
        public dbDiabetesContext()
        {
        }

        public dbDiabetesContext(DbContextOptions<dbDiabetesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Calendario7pasos> Calendario7pasos { get; set; }
        public virtual DbSet<Citas> Citas { get; set; }
        public virtual DbSet<Conferencias> Conferencias { get; set; }
        public virtual DbSet<DatosCita> DatosCita { get; set; }
        public virtual DbSet<ElementoPermitido> ElementoPermitido { get; set; }
        public virtual DbSet<Elementos> Elementos { get; set; }
        public virtual DbSet<ElementosPermisos> ElementosPermisos { get; set; }
        public virtual DbSet<MedicionGlucosa> MedicionGlucosa { get; set; }
        public virtual DbSet<MedicionHb1c> MedicionHb1c { get; set; }
        public virtual DbSet<MedicionMesual> MedicionMesual { get; set; }
        public virtual DbSet<Modulos> Modulos { get; set; }
        public virtual DbSet<PerfilModulos> PerfilModulos { get; set; }
        public virtual DbSet<Permisos> Permisos { get; set; }
        public virtual DbSet<Personas> Personas { get; set; }
        public virtual DbSet<PesoTalla> PesoTalla { get; set; }
        public virtual DbSet<PreguntasBeck> PreguntasBeck { get; set; }
        public virtual DbSet<PruebaBeck> PruebaBeck { get; set; }
        public virtual DbSet<RespuestasBeck> RespuestasBeck { get; set; }
        public virtual DbSet<TipoActividad> TipoActividad { get; set; }
        public virtual DbSet<TipoCitas> TipoCitas { get; set; }
        public virtual DbSet<TipoEspecialista> TipoEspecialista { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=DESKTOP-GBFFEJ9;Initial Catalog=dbDiabetes;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Calendario7pasos>(entity =>
            {
                entity.HasKey(e => e.IdCalendario7pasos)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("CALENDARIO_7PASOS");

                entity.Property(e => e.IdCalendario7pasos).HasColumnName("ID_CALENDARIO_7PASOS");

                entity.Property(e => e.FechaCalendario7pasos)
                    .HasColumnName("FECHA_CALENDARIO_7PASOS")
                    .HasColumnType("datetime");

                entity.Property(e => e.HoraCaledario).HasColumnName("HORA_CALEDARIO");

                entity.Property(e => e.IdPersona).HasColumnName("ID_PERSONA");

                entity.Property(e => e.IdTipoActividad).HasColumnName("ID_TIPO_ACTIVIDAD");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Calendario7pasos)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefPERSONAS100");

                entity.HasOne(d => d.IdTipoActividadNavigation)
                    .WithMany(p => p.Calendario7pasos)
                    .HasForeignKey(d => d.IdTipoActividad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefTIPO_ACTIVIDAD99");
            });

            modelBuilder.Entity<Citas>(entity =>
            {
                entity.HasKey(e => e.IdCitas)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("CITAS");

                entity.Property(e => e.IdCitas).HasColumnName("ID_CITAS");

                entity.Property(e => e.FechaCita)
                    .HasColumnName("FECHA_CITA")
                    .HasColumnType("date");

                entity.Property(e => e.HoraCita).HasColumnName("HORA_CITA");

                entity.Property(e => e.IdDatoscita).HasColumnName("ID_DATOSCITA");

                entity.Property(e => e.IdPersona).HasColumnName("ID_PERSONA");

                entity.Property(e => e.IdTipoCitas).HasColumnName("ID_TIPO_CITAS");

                entity.HasOne(d => d.IdDatoscitaNavigation)
                    .WithMany(p => p.Citas)
                    .HasForeignKey(d => d.IdDatoscita)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefDATOS_CITA95");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Citas)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefPERSONAS97");

                entity.HasOne(d => d.IdTipoCitasNavigation)
                    .WithMany(p => p.Citas)
                    .HasForeignKey(d => d.IdTipoCitas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefTIPO_CITAS96");
            });

            modelBuilder.Entity<Conferencias>(entity =>
            {
                entity.HasKey(e => e.IdConferencias)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("CONFERENCIAS");

                entity.Property(e => e.IdConferencias).HasColumnName("ID_CONFERENCIAS");

                entity.Property(e => e.FechaConferencias)
                    .HasColumnName("FECHA_CONFERENCIAS")
                    .HasColumnType("date");

                entity.Property(e => e.HoraConferencias).HasColumnName("HORA_CONFERENCIAS");

                entity.Property(e => e.IdPersona).HasColumnName("ID_PERSONA");

                entity.Property(e => e.NombreConferencia)
                    .IsRequired()
                    .HasColumnName("NOMBRE_CONFERENCIA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Conferencias)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefPERSONAS98");
            });

            modelBuilder.Entity<DatosCita>(entity =>
            {
                entity.HasKey(e => e.IdDatoscita)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("DATOS_CITA");

                entity.Property(e => e.IdDatoscita).HasColumnName("ID_DATOSCITA");

                entity.Property(e => e.Consultorio).HasColumnName("CONSULTORIO");

                entity.Property(e => e.IdEspecialista).HasColumnName("ID_ESPECIALISTA");

                entity.Property(e => e.NombreEspecialista)
                    .IsRequired()
                    .HasColumnName("NOMBRE_ESPECIALISTA")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoEspecialista)
                    .IsRequired()
                    .HasColumnName("TELEFONO_ESPECIALISTA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEspecialistaNavigation)
                    .WithMany(p => p.DatosCita)
                    .HasForeignKey(d => d.IdEspecialista)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefTIPO_ESPECIALISTA94");
            });

            modelBuilder.Entity<ElementoPermitido>(entity =>
            {
                entity.HasKey(e => e.IdElementoPermitido)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("ELEMENTO_PERMITIDO");

                entity.Property(e => e.IdElementoPermitido).HasColumnName("ID_ELEMENTO_PERMITIDO");

                entity.Property(e => e.IdElementosPermisos).HasColumnName("ID_ELEMENTOS_PERMISOS");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("ID_TIPO_USUARIO");

                entity.HasOne(d => d.IdElementosPermisosNavigation)
                    .WithMany(p => p.ElementoPermitido)
                    .HasForeignKey(d => d.IdElementosPermisos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefELEMENTOS_PERMISOS111");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.ElementoPermitido)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefTIPO_USUARIO108");
            });

            modelBuilder.Entity<Elementos>(entity =>
            {
                entity.HasKey(e => e.IdElementos)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("ELEMENTOS");

                entity.Property(e => e.IdElementos).HasColumnName("ID_ELEMENTOS");

                entity.Property(e => e.IdModulo).HasColumnName("ID_MODULO");

                entity.Property(e => e.NomElemento)
                    .IsRequired()
                    .HasColumnName("NOM_ELEMENTO")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdModuloNavigation)
                    .WithMany(p => p.Elementos)
                    .HasForeignKey(d => d.IdModulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefMODULOS114");
            });

            modelBuilder.Entity<ElementosPermisos>(entity =>
            {
                entity.HasKey(e => e.IdElementosPermisos)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("ELEMENTOS_PERMISOS");

                entity.Property(e => e.IdElementosPermisos).HasColumnName("ID_ELEMENTOS_PERMISOS");

                entity.Property(e => e.IdElementos).HasColumnName("ID_ELEMENTOS");

                entity.Property(e => e.IdPermisos).HasColumnName("ID_PERMISOS");

                entity.HasOne(d => d.IdElementosNavigation)
                    .WithMany(p => p.ElementosPermisos)
                    .HasForeignKey(d => d.IdElementos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefELEMENTOS109");

                entity.HasOne(d => d.IdPermisosNavigation)
                    .WithMany(p => p.ElementosPermisos)
                    .HasForeignKey(d => d.IdPermisos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefPERMISOS110");
            });

            modelBuilder.Entity<MedicionGlucosa>(entity =>
            {
                entity.HasKey(e => e.IdMedicionGlucosa)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("MEDICION_GLUCOSA");

                entity.Property(e => e.IdMedicionGlucosa).HasColumnName("ID_MEDICION_GLUCOSA");

                entity.Property(e => e.FechaMedicionGlucosa)
                    .HasColumnName("FECHA_MEDICION_GLUCOSA")
                    .HasColumnType("datetime");

                entity.Property(e => e.HoraMedicionGlucosa).HasColumnName("HORA_MEDICION_GLUCOSA");

                entity.Property(e => e.IdPruebaBeck).HasColumnName("ID_PRUEBA_BECK");

                entity.Property(e => e.ResultadoMedicionGlucosa).HasColumnName("RESULTADO_MEDICION_GLUCOSA");

                entity.HasOne(d => d.IdPruebaBeckNavigation)
                    .WithMany(p => p.MedicionGlucosa)
                    .HasForeignKey(d => d.IdPruebaBeck)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefPRUEBA_BECK101");
            });

            modelBuilder.Entity<MedicionHb1c>(entity =>
            {
                entity.HasKey(e => e.IdMedicionHb1c)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("MEDICION_HB1C");

                entity.Property(e => e.IdMedicionHb1c).HasColumnName("ID_MEDICION_HB1C");

                entity.Property(e => e.FechaMedicionHb1c)
                    .HasColumnName("FECHA_MEDICION_HB1C")
                    .HasColumnType("date");

                entity.Property(e => e.HoraMedicionHb1c).HasColumnName("HORA_MEDICION_HB1C");

                entity.Property(e => e.IdPersona).HasColumnName("ID_PERSONA");

                entity.Property(e => e.ResutadoMedicionHb1c)
                    .IsRequired()
                    .HasColumnName("RESUTADO_MEDICION_HB1C")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.MedicionHb1c)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefPERSONAS106");
            });

            modelBuilder.Entity<MedicionMesual>(entity =>
            {
                entity.HasKey(e => e.IdMedicionMensual)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("MEDICION_MESUAL");

                entity.Property(e => e.IdMedicionMensual).HasColumnName("ID_MEDICION_MENSUAL");

                entity.Property(e => e.FechaMedicionMensual)
                    .HasColumnName("FECHA_MEDICION_MENSUAL")
                    .HasColumnType("datetime");

                entity.Property(e => e.HoraMedicionMensual).HasColumnName("HORA_MEDICION_MENSUAL");

                entity.Property(e => e.IdPersona).HasColumnName("ID_PERSONA");

                entity.Property(e => e.ResultadoMedicionMensual)
                    .IsRequired()
                    .HasColumnName("RESULTADO_MEDICION_MENSUAL")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.MedicionMesual)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefPERSONAS105");
            });

            modelBuilder.Entity<Modulos>(entity =>
            {
                entity.HasKey(e => e.IdModulo)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("MODULOS");

                entity.Property(e => e.IdModulo).HasColumnName("ID_MODULO");

                entity.Property(e => e.DesModulo)
                    .HasColumnName("DES_MODULO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NomModulo)
                    .IsRequired()
                    .HasColumnName("NOM_MODULO")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PerfilModulos>(entity =>
            {
                entity.HasKey(e => e.IdPerfilModulos)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("PERFIL_MODULOS");

                entity.Property(e => e.IdPerfilModulos).HasColumnName("ID_PERFIL_MODULOS");

                entity.Property(e => e.IdModulo).HasColumnName("ID_MODULO");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("ID_TIPO_USUARIO");

                entity.HasOne(d => d.IdModuloNavigation)
                    .WithMany(p => p.PerfilModulos)
                    .HasForeignKey(d => d.IdModulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefMODULOS115");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.PerfilModulos)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefTIPO_USUARIO113");
            });

            modelBuilder.Entity<Permisos>(entity =>
            {
                entity.HasKey(e => e.IdPermisos)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("PERMISOS");

                entity.Property(e => e.IdPermisos).HasColumnName("ID_PERMISOS");

                entity.Property(e => e.NomPermisos)
                    .IsRequired()
                    .HasColumnName("NOM_PERMISOS")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Personas>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("PERSONAS");

                entity.Property(e => e.IdPersona).HasColumnName("ID_PERSONA");

                entity.Property(e => e.Anioscondiabetes).HasColumnName("ANIOSCONDIABETES");

                entity.Property(e => e.ApellidoMater)
                    .IsRequired()
                    .HasColumnName("APELLIDO_MATER")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoPater)
                    .IsRequired()
                    .HasColumnName("APELLIDO_PATER")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("DIRECCION")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaInicio)
                    .HasColumnName("FECHA_INICIO")
                    .HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnName("TELEFONO")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PesoTalla>(entity =>
            {
                entity.HasKey(e => e.IdPesoTalla)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("PESO_TALLA");

                entity.Property(e => e.IdPesoTalla).HasColumnName("ID_PESO_TALLA");

                entity.Property(e => e.FechaPesoTalla)
                    .HasColumnName("FECHA_PESO_TALLA")
                    .HasColumnType("date");

                entity.Property(e => e.IdPersona).HasColumnName("ID_PERSONA");

                entity.Property(e => e.ResultadoPeso).HasColumnName("RESULTADO_PESO");

                entity.Property(e => e.ResultadoTalla).HasColumnName("RESULTADO_TALLA");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.PesoTalla)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefPERSONAS104");
            });

            modelBuilder.Entity<PreguntasBeck>(entity =>
            {
                entity.HasKey(e => e.IdPreguntasBeck)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("PREGUNTAS_BECK");

                entity.Property(e => e.IdPreguntasBeck).HasColumnName("ID_PREGUNTAS_BECK");

                entity.Property(e => e.IdRespuestasBeck).HasColumnName("ID_RESPUESTAS_BECK");

                entity.Property(e => e.NombrePreguntasBeck)
                    .IsRequired()
                    .HasColumnName("NOMBRE_PREGUNTAS_BECK")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRespuestasBeckNavigation)
                    .WithMany(p => p.PreguntasBeck)
                    .HasForeignKey(d => d.IdRespuestasBeck)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefRESPUESTAS_BECK116");
            });

            modelBuilder.Entity<PruebaBeck>(entity =>
            {
                entity.HasKey(e => e.IdPruebaBeck)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("PRUEBA_BECK");

                entity.Property(e => e.IdPruebaBeck).HasColumnName("ID_PRUEBA_BECK");

                entity.Property(e => e.IdPersona).HasColumnName("ID_PERSONA");

                entity.Property(e => e.IdPreguntasBeck).HasColumnName("ID_PREGUNTAS_BECK");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.PruebaBeck)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefPERSONAS103");

                entity.HasOne(d => d.IdPreguntasBeckNavigation)
                    .WithMany(p => p.PruebaBeck)
                    .HasForeignKey(d => d.IdPreguntasBeck)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefPREGUNTAS_BECK102");
            });

            modelBuilder.Entity<RespuestasBeck>(entity =>
            {
                entity.HasKey(e => e.IdRespuestasBeck)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("RESPUESTAS_BECK");

                entity.Property(e => e.IdRespuestasBeck).HasColumnName("ID_RESPUESTAS_BECK");

                entity.Property(e => e.NombreRespuestasBeck)
                    .IsRequired()
                    .HasColumnName("NOMBRE_RESPUESTAS_BECK")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoActividad>(entity =>
            {
                entity.HasKey(e => e.IdTipoActividad)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("TIPO_ACTIVIDAD");

                entity.Property(e => e.IdTipoActividad).HasColumnName("ID_TIPO_ACTIVIDAD");

                entity.Property(e => e.NombreTipoActividad)
                    .IsRequired()
                    .HasColumnName("NOMBRE_TIPO_ACTIVIDAD")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoCitas>(entity =>
            {
                entity.HasKey(e => e.IdTipoCitas)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("TIPO_CITAS");

                entity.Property(e => e.IdTipoCitas).HasColumnName("ID_TIPO_CITAS");

                entity.Property(e => e.NiombreTipoCitas)
                    .IsRequired()
                    .HasColumnName("NIOMBRE_TIPO_CITAS")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoEspecialista>(entity =>
            {
                entity.HasKey(e => e.IdEspecialista)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("TIPO_ESPECIALISTA");

                entity.Property(e => e.IdEspecialista).HasColumnName("ID_ESPECIALISTA");

                entity.Property(e => e.NomTipoespecialista)
                    .IsRequired()
                    .HasColumnName("NOM_TIPOESPECIALISTA")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("TIPO_USUARIO");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("ID_TIPO_USUARIO");

                entity.Property(e => e.NombreTipoUsuario)
                    .IsRequired()
                    .HasColumnName("NOMBRE_TIPO_USUARIO")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("USUARIO");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.Contrasena)
                    .HasColumnName("CONTRASENA")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IdPersona).HasColumnName("ID_PERSONA");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("ID_TIPO_USUARIO");

                entity.Property(e => e.Telefono)
                    .HasColumnName("TELEFONO")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefPERSONAS107");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefTIPO_USUARIO112");
            });
        }
    }
}
