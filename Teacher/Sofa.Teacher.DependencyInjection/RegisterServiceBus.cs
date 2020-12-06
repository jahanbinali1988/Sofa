using Autofac;
using MassTransit;
using Sofa.SharedKernel;
using Sofa.Teacher.Consumer.LessonPlanConsumer.RegisterLessonPlan;
using Sofa.Teacher.Consumer.UserConsumer.RegisterUser;
using Sofa.Teacher.Consumer.ReisterPost;
using Sofa.Teacher.Repository;
using Sofa.Teacher.Consumer.UserConsumer.UpdateUserIsActiveStatus;
using Sofa.Teacher.Consumer.UserConsumer.UpdateUserIsDeletedStatus;
using Sofa.Teacher.Consumer.CourseConsumer.RegisterCourse;
using Sofa.Teacher.Consumer.CourseConsumer.UpdateCourseIsActiveStatus;
using Sofa.Teacher.Consumer.CourseConsumer.UpdateCourseIsDeletedStatus;
using Sofa.Teacher.Consumer.FieldConsumer.RegisterField;
using Sofa.Teacher.Consumer.FieldConsumer.UpdateFieldIsActiveStatus;
using Sofa.Teacher.Consumer.FieldConsumer.UpdateFieldIsDeletedStatus;
using Sofa.Teacher.Consumer.InstituteConsumer.RegisterInstitute;
using Sofa.Teacher.Consumer.InstituteConsumer.UpdateInstituteIsActiveStatus;
using Sofa.Teacher.Consumer.InstituteConsumer.UpdateInstituteIsDeletedStatus;
using Sofa.Teacher.Consumer.LessonPlanConsumer.UpdateLessonPlanIsActiveStatus;
using Sofa.Teacher.Consumer.LessonPlanConsumer.UpdateLessonPlanIsDeletedStatus;
using Sofa.Teacher.Consumer.PostConsumer.UpdatePostIsDeletedStatus;
using Sofa.Teacher.Consumer.PostConsumer.UpdatePostIsActiveStatus;
using Sofa.Teacher.Consumer.SessionConsumer.RegisterSession;
using Sofa.Teacher.Consumer.SessionConsumer.UpdateSessionIsActiveStatus;
using Sofa.Teacher.Consumer.SessionConsumer.UpdateSessionIsDeletedStatus;
using Sofa.Teacher.Consumer.TermConsumer.RegisterTerm;
using Sofa.Teacher.Consumer.TermConsumer.UpdateTermIsActiveStatus;
using Sofa.Teacher.Consumer.TermConsumer.UpdateTermIsDeletedStatus;

namespace Sofa.Teacher.DependencyResolver
{
    public class RegisterServiceBus : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register<IBusControl>(context =>
            {
                var busSettingProvider = context.Resolve<IServiceBusSettingProvider>();
                var busSettings = busSettingProvider.GetBusSetting();
                var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host(busSettings.HostAddress, h =>
                    {
                        h.Username(busSettings.Username);
                        h.Password(busSettings.Password);
                    });

                    cfg.ReceiveEndpoint(busSettings.QueueName, x =>
                    {
                        #region Course Consumers
                            x.Instance(new RegisterCourseEventConsumer(context.Resolve<IUnitOfWork>(), context.Resolve<ILogger>()));
                            x.Instance(new UpdateCourseIsActiveStatusEventConsumer(context.Resolve<IUnitOfWork>(), context.Resolve<ILogger>()));
                            x.Instance(new UpdateCourseIsDeletedStatusEventConsumer(context.Resolve<IUnitOfWork>(), context.Resolve<ILogger>()));
                        #endregion
                        #region Field Consumers
                            x.Instance(new RegisterFieldEventConsumer(context.Resolve<IUnitOfWork>(), context.Resolve<ILogger>()));
                            x.Instance(new UpdateFieldIsActiveStatusEventConsumer(context.Resolve<IUnitOfWork>(), context.Resolve<ILogger>()));
                            x.Instance(new UpdateFieldIsDeletedStatusEventConsumer(context.Resolve<IUnitOfWork>(), context.Resolve<ILogger>()));
                        #endregion
                        #region Institute Consumers
                            x.Instance(new RegisterInstituteEventConsumer(context.Resolve<IUnitOfWork>(), context.Resolve<ILogger>()));
                            x.Instance(new UpdateInstituteIsActiveStatusEventConsumer(context.Resolve<IUnitOfWork>(), context.Resolve<ILogger>()));
                            x.Instance(new UpdateInstituteIsDeletedStatusEventConsumer(context.Resolve<IUnitOfWork>(), context.Resolve<ILogger>()));
                        #endregion
                        #region LessonPlan Consumers
                            x.Instance(new RegisterLessonPlanEventConsumer(context.Resolve<IUnitOfWork>(), context.Resolve<ILogger>()));
                            x.Instance(new UpdateLessonPlanIsActiveStatusEventConsumer(context.Resolve<IUnitOfWork>(), context.Resolve<ILogger>()));
                            x.Instance(new UpdateLessonPlanIsDeletedStatusEventConsumer(context.Resolve<IUnitOfWork>(), context.Resolve<ILogger>()));
                        #endregion
                        #region Post Consumers
                            x.Instance(new RegisterPostEventConsumer(context.Resolve<IUnitOfWork>(), context.Resolve<ILogger>()));
                            x.Instance(new UpdatePostIsActiveStatusEventConsumer(context.Resolve<IUnitOfWork>(), context.Resolve<ILogger>()));
                            x.Instance(new UpdatePostIsDeletedStatusEventConsumer(context.Resolve<IUnitOfWork>(), context.Resolve<ILogger>()));
                        #endregion
                        #region Session Consumers
                            x.Instance(new RegisterSessionEventConsumer(context.Resolve<IUnitOfWork>(), context.Resolve<ILogger>()));
                            x.Instance(new UpdateSessionIsActiveStatusEventConsumer(context.Resolve<IUnitOfWork>(), context.Resolve<ILogger>()));
                            x.Instance(new UpdateSessionIsDeletedStatusEventConsumer(context.Resolve<IUnitOfWork>(), context.Resolve<ILogger>()));
                        #endregion
                        #region Term Consumers
                            x.Instance(new RegisterTermEventConsumer(context.Resolve<IUnitOfWork>(), context.Resolve<ILogger>()));
                            x.Instance(new UpdateTermIsActiveStatusEventConsumer(context.Resolve<IUnitOfWork>(), context.Resolve<ILogger>()));
                            x.Instance(new UpdateTermIsDeletedStatusEventConsumer(context.Resolve<IUnitOfWork>(), context.Resolve<ILogger>()));
                        #endregion
                        #region User Consumers
                            x.Instance(new RegisterUserEventConsumer(context.Resolve<IUnitOfWork>(), context.Resolve<ILogger>()));
                            x.Instance(new UpdateUserIsActiveStatusEventConsumer(context.Resolve<IUnitOfWork>(), context.Resolve<ILogger>()));
                            x.Instance(new UpdateUserIsDeletedStatusEventConsumer(context.Resolve<IUnitOfWork>(), context.Resolve<ILogger>()));
                        #endregion
                    });
                });
                return busControl;
            })
                .SingleInstance()
                .As<IBusControl>()
                .As<IBus>();
        }
    }
}
