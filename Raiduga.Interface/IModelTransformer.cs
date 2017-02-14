namespace Raiduga.Interface
{
	public interface IModelTransformer
	{
		TEntity GetEntity<TEntity>(IViewModel viewModel)
			where TEntity : class, IEntity;

		TViewModel GetViewModel<TViewModel>(IEntity entity)
			where TViewModel : class, IViewModel;
	}
}
