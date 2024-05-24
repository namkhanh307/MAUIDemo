using MAUIDemo.ViewModels;

namespace MAUIDemo;

public partial class AddEmployee : ContentPage
{
	public AddEmployee(AddEmployeeViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}