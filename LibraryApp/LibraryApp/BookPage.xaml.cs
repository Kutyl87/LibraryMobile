using System;
using System.Collections.Generic;
using LibraryApp.Model;
using Xamarin.Forms;

namespace LibraryApp
{	
	public partial class BookPage : ContentPage
	{	
		public BookPage (Book book)
		{
			InitializeComponent ();
			Title.Text = book.Title;
			Author.Text = book.Author;
		}
	}
}

