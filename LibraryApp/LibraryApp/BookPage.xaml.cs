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
			Img.Source = book.ImageUrl;
			Description.Text = book.BookDescription;
			Rating.Text = book.Rating.ToString();
			Genre.Text = book.Genre;

		}
	}
}

