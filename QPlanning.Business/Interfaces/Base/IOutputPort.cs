namespace QPlanning.Business.Interfaces.Base
{
	public interface IOutputPort<in TUseCaseResponse>
	{
		void Handle(TUseCaseResponse response);
	}
}
