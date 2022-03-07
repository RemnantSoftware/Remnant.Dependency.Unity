using Remnant.Dependency.Interface;
using System;
using Unity;

namespace Remnant.Dependency.Unity
{
	public class UnityAdapter : IContainer
	{
		private readonly IUnityContainer _container;

		public UnityAdapter(IUnityContainer unityContainer)
		{
			_container = unityContainer ?? throw new ArgumentNullException(nameof(unityContainer));
		}

		public IContainer Clear()
		{
			throw new NotSupportedException("Unity does not support 'Clear'.");
		}

		public IContainer DeRegister<TType>() where TType : class
		{
			throw new NotSupportedException("Deregister not supported, lifetime manager not used to remove objects.");

			//foreach (var registration in _container.Registrations
			//		.Where(p => 
			//			p.RegisteredType == typeof(TType) && 
			//			p.Name == typeof(TType).Name	&& 
			//			p.LifetimeManager.GetType() == typeof(ContainerControlledLifetimeManager)))
			//{
			//	registration.LifetimeManager.RemoveValue();
			//}
			//return this;
		}

		public IContainer DeRegister(object instance)
		{
			throw new NotSupportedException("Deregister not supported, lifetime manager not used to remove objects.");
		}

		public IContainer Register<TType>(object instance) where TType : class
		{
			_container.RegisterInstance<TType>(instance as TType);
			return this;
		}

		public IContainer Register(Type type, object instance)
		{
			_container.RegisterInstance(type, instance);
			return this;
		}

		public IContainer Register(object instance)
		{
			_container.RegisterInstance(instance);
			return this;
		}

		public IContainer Register<TType>() where TType : class, new()
		{
			_container.RegisterInstance(typeof(TType), new TType());
			return this;
		}

		public IContainer Register<TType, TObject>()
			where TType : class
			where TObject : class, new()
		{
			_container.RegisterInstance(typeof(TType), new TObject());
			return this;
		}

		public TType ResolveInstance<TType>() where TType : class
		{
			return _container.Resolve<TType>();
		}

		public TContainer InternalContainer<TContainer>() where TContainer : class
		{
			if (_container as TContainer == null)
				throw new InvalidCastException($"The internal container is of type {_container.GetType().FullName} and cannot be cast to {typeof(TContainer).FullName}");

			return _container as TContainer;
		}
	}
}
