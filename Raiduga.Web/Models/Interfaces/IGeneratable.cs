namespace Raiduga.Web.Models.Interfaces
{
	public interface IGeneratable<TDbModel, TViewModel>
	{
		TViewModel FromDbModel(TDbModel model);

		TDbModel ToDbModel();
	}
}
