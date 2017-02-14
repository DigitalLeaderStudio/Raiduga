namespace Raiduga.ModelTransformers
{
	using Raiduga.Interface;
	using Raiduga.Interface.Attribute;
	using System;
	using System.Collections;
	using System.Linq;

	public class ModelTransformer : IModelTransformer
	{
		#region GetEntity from view model

		public TEntity GetEntity<TEntity>(IViewModel viewModel)
			where TEntity : class, IEntity
		{
			TEntity result = Activator.CreateInstance<TEntity>();

			//Get only value attributes
			var viewModelMappedProperies =
				viewModel.GetType()
				.GetProperties()
				.Where(p => p.IsDefined(typeof(MapToValueAttribute), true));

			foreach (var vmProperty in viewModelMappedProperies)
			{
				var value = vmProperty.GetValue(viewModel);
				var prop = result.GetType().GetProperties().Where(p => p.Name.Equals(vmProperty.Name)).First();
				prop.SetValue(result, value);
			}

			//Get file
			var viewModelMappedToFileProperty = viewModel.GetType().GetMethods()
				.Where(p => p.IsDefined(typeof(MapToFileAttribute), true)).FirstOrDefault();

			if (viewModelMappedToFileProperty != null)
			{
				var attrValue = viewModelMappedToFileProperty
					.GetCustomAttributes(typeof(MapToFileAttribute), true)
					.First() as MapToFileAttribute;

				var prop = result.GetType().GetProperties().Where(p => p.Name.Equals(attrValue.EntityPropertyName)).First();
				var value = viewModelMappedToFileProperty.Invoke(viewModel, null);
				prop.SetValue(result, value);
			}

			return result;
		}

		#endregion

		#region GetViewModel from entity

		public TViewModel GetViewModel<TViewModel>(IEntity entity)
			where TViewModel : class, IViewModel
		{
			TViewModel result = Activator.CreateInstance<TViewModel>();

			result = (TViewModel)ReadDataFromEntity(result.GetType(), entity);

			return result;
		}


		#endregion

		#region helpers

		private object GetListValue(Type propType, object list)
		{
			var result = Activator.CreateInstance(propType);
			var add = result.GetType().GetMethod("Add");

			var viewModelType = propType.GetGenericArguments().Single();
			var genericType = list.GetType().GetGenericArguments().Single();

			foreach (var value in list as IEnumerable)
			{
				var listValue = ReadDataFromEntity(viewModelType, value);
				add.Invoke(result, new[] { listValue });
			}

			return result;
		}

		private object GetComplexValue(Type propType, object entity)
		{
			if (entity == null) return null;

			var result = Activator.CreateInstance(propType);

			var viewModelMappedProperies = propType
				.GetProperties()
				.Where(p => p.IsDefined(typeof(MapToValueAttribute), true) || p.IsDefined(typeof(MapToEntityAttribute), true));

			foreach (var vmProperty in viewModelMappedProperies)
			{
				var entityType = entity.GetType();
				var value = entity;
				if (entityType.IsGenericType) // if entity value is list system.data.entity.dynamicproxies
				{
					var genericType = entityType.GetGenericArguments().Single();
					var collection = Activator.CreateInstance(genericType);
					foreach (var vv in entity as IEnumerable)
					{
						value = vv;
					}
				}

				var entityProperties = value.GetType().GetProperties();

				var valueByName = entityProperties.Where(p => p.Name.Equals(vmProperty.Name)).First().GetValue(value);

				if (vmProperty.IsDefined(typeof(MapToValueAttribute), true))
				{
					vmProperty.SetValue(result, valueByName);
				}
				else
				{
					vmProperty.SetValue(result, GetComplexValue(vmProperty.PropertyType, valueByName));
				}
			}

			return result;
		}

		private object ReadDataFromEntity(Type viewModelType, object entity)
		{
			var result = Activator.CreateInstance(viewModelType);

			var viewModelMappedProperies = viewModelType.GetProperties()
				.Where(p => p.IsDefined(typeof(MapToValueAttribute), true)
					|| p.IsDefined(typeof(MapToEntityAttribute), true)
					|| p.IsDefined(typeof(MapToListAttribute), true));

			var entityProperties = entity.GetType().GetProperties();

			foreach (var vmProperty in viewModelMappedProperies)
			{
				var valueByName = entityProperties
					.Where(p => p.Name.Equals(vmProperty.Name)).First()
					.GetValue(entity);

				if (vmProperty.IsDefined(typeof(MapToValueAttribute), true))
				{
					vmProperty.SetValue(result, valueByName);
				}
				else if (vmProperty.IsDefined(typeof(MapToEntityAttribute), true))
				{
					vmProperty.SetValue(result, GetComplexValue(vmProperty.PropertyType, valueByName));
				}
				else if (vmProperty.IsDefined(typeof(MapToListAttribute), true))
				{
					vmProperty.SetValue(result, GetListValue(vmProperty.PropertyType, valueByName));
				}
			}

			return result;
		}

		#endregion


	}
}
