namespace QPlanning.Business.Dto.Base
{
	public sealed class Error
	{		
		public Error(string code, string description)
		{
			Code = code;
			Description = description;
		}

		public string Code { get; }
		public string Description { get; }
	}
}
