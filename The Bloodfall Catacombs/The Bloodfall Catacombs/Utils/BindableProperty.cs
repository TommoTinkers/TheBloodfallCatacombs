using System;

namespace The_Bloodfall_Catacombs.Utils
{
	public interface IBindableProperty<TProp>
	{
		void RegisterHandlerAndCallIt(Action<TProp> handler);
		event Action<TProp> OnSet;
		TProp Value { get; }
	}

	public class BindableProperty<TProp> : IBindableProperty<TProp>
	{
		private TProp value;

		public event Action<TProp> OnSet;

		public void RegisterHandlerAndCallIt(Action<TProp> handler)
		{
			OnSet += handler;
			handler?.Invoke(value);
		}
		
		public TProp Value
		{
			get => value;
			set
			{
				this.value = value;
				OnSet?.Invoke(value);
			}
		}
	}
}