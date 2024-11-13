//using ConsoleApp1;
//using Ninject;

//var ninjectKernal = new StandardKernel();
//ninjectKernal.Bind<IRepository>().To<RepositoryOrm>();
//var repository = ninjectKernal.Get<IRepository>();
//repository.GetAll();

using Autofac;
using ConsoleApp1;

var builder=new ContainerBuilder();
builder.RegisterType<RepositoryOrm>().As<IRepository>();
var container=builder.Build();
var repository=container.Resolve<IRepository>();
repository.GetAll();