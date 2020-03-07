using System;

namespace The_Bloodfall_Catacombs.Utils
{
	public interface IBindableProperty<TProp>
	{
		void RegisterHandlerAndCallIt(Action<TProp> handler);
		event Action<TProp> OnChange;
		TProp Value { get; }
	}

	public class BindableProperty<TProp> : IBindableProperty<TProp>
	{
		private TProp value;

		public event Action<TProp> OnChange;

		public void RegisterHandlerAndCallIt(Action<TProp> handler)
		{
			OnChange += handler;
			handler?.Invoke(value);
		}
		
		public TProp Value
		{
			get => value;
			set
			{
				this.value = value;
				OnChange?.Invoke(value);
			}
		}
	}
}