using System;
using Gtk;
using System.Reflection;


using PReflection;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		//showInfo (typeof(Categoria));
		//showInfo (typeof(Articulo));

		//Type type = typeof(MainWindow);
		Assembly assembly = Assembly.GetExecutingAssembly();

		foreach (Type type in assembly.GetTypes())
			if (type.IsDefined (typeof(EntityAttribute), true)) {
				//Console.WriteLine ("type.Name={0}", type.Name);
				EntityAttribute entityAttribute = (EntityAttribute)Attribute.GetCustomAttribute (type, typeof(EntityAttribute));
				Console.WriteLine ("type.Name={0} entiryAttribute.TableName={1}", type.Name, entityAttribute.TableName);
			}

		Categoria categoria = new Categoria (33, "Treinta y tres");

		showValues (categoria);

	}


	private void showValues(object obj){
		Type type = obj.GetType ();
		FieldInfo[] fields = type.GetFields (BindingFlags.Instance | BindingFlags.NonPublic);
		foreach (FieldInfo field in fields){
			object value = field.GetValue (obj);
			Console.WriteLine ("NameField = {0,-50} Type = {1}", field.Name, value);

		}


	}


	private void showInfo(Type type){
		Console.WriteLine ("Name = {0}",type.Name);
	

	PropertyInfo[] properties = type.GetProperties();
	foreach (PropertyInfo property in properties){
		Console.WriteLine ("NameProperty = {0,-50} Type = {1}", property.Name, property.PropertyType);

	}

		FieldInfo[] fields = type.GetFields (BindingFlags.Instance | BindingFlags.NonPublic);
		foreach (FieldInfo field in fields){
			if(field.IsDefined(typeof(IdAtribute),true))
			Console.WriteLine ("NameField = {0,-50} Type = {1}", field.Name, field.FieldType);

		}
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

}
