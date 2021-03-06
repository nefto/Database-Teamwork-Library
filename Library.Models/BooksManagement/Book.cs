﻿using Library.Models.BookOrders;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models.BooksManagement
{
    public class Book : IDbEntity
    {
        public Book(string title, string description, Author author, Genre genre, int year, double price)
        {
            this.Title = title;
            this.Description = description;
            this.Author = author;
            this.Genres = new List<Genre>();
            this.Genres.Add(genre);
            this.Year = year;
            this.Price = price;
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]

        public string Title { get; set; }

        [JsonProperty("description")]
        [Column(TypeName = "text")]
        public string Description { get; set; }

        [Required]
        [JsonProperty("author")]
        public virtual Author Author { get; set; }


        [JsonProperty("genres")]
        public virtual ICollection<Genre> Genres { get; set; }

        [Required]
        [JsonProperty("year")]
        public int Year { get; set; }

        [Required]
        [JsonProperty("price")]
        public double Price { get; set; }

        public virtual BooksOrder Order { get; set; }
    }
}
