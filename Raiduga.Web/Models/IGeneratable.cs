namespace Raiduga.Web.Models
{
	public interface IGeneratable<TDbModel, TViewModel>
	{
		TViewModel FromDbModel(TDbModel model);

		TDbModel ToDbModel();
	}
}
