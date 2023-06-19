using AutoMapper;
using BookStore.BL.Interfaces;
using BookStore.BL.Services;
using BookStore.DL.Interfaces;
using Moq;
using System.ComponentModel;
using System.Net;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookStore.Test

{
    public class BookServiceTest
    {
        private Mock<IBookRepository> _bookRepository;
        private Mock<IMapper> _mapper;

        private readonly IList<Book> Books = new List<Book>()
        {
            new Book()
            {
                Id = 1,
                Name = "UnitTestBook",
                ReleaseDate = 2023
            },
            new Book()
            {
                Id = 2,
                Name = "TestBookSecond",
                ReleaseDate = 2023
            }
        };

        public BookServiceTest()
        {
            _bookRepository = new Mock<IBookRepository>();
            _mapper = new Mock<IMapper>();
        }

        [Fact]
        public async Task Book_GetAll_Count()
        {
            var expectedCount = 2;

            _bookRepository.Setup(x => x.GetAll()).Returns(async () => Task.FromResult(Books));

            var service = new BookService(_bookRepository.Object);

            var result = await service.GetAll();

            var books = result.ToList();

            Assert.Equal(expectedCount, books.Count);
        }
    }

    [Fact]
public async Task Book_GetById_Ok()

    {
        var bookId = new Guid("60153cb8 - d993 - 4dcc - 8fc8 - 416f865524f9");
        var expectedBook = new Guid("ec87e5a4-bdf5-49eb-b5fe-66200ea1187c");
    }

    [Fact]
    public async Task Book_GetAll_Count()
    {
        var expectedCount = 2;

        _bookRepository.Setup(x => x.GetAll()).Returns(async () => Task.FromResult(Books));

        var service = new BookService(_bookRepository.Object);

        var result = await service.GetById(bookId);

        var books = result.ToList();

        Assert.Equal(expected.Book,result.book);
        Assert.NotNull(result);
        Assert.Equal(expected.Title, result.Title);
    }


    [Fact]
    
   
        public async Task Book_GetById_Not_Found()

    {
        var bookId = new Guid("60153cb8 - d993 - 4dcc - 8fc8 - 416f865524f9");
        _bookRepository.Setup(x => x.GetById(book)).Returns(async () => Book.FirstOrDefault(x => x.Id == book));

        var service = new BookService(_bookRepository.Object);

        var result = await service.GetById(bookId);

        Assert.Null(result);
       
    }

    [Fact]

    public async Task Book_Delete_By_Id()
    {
        var bookId = new Guid("60153cb8 - d993 - 4dcc - 8fc8 - 416f865524f9");
        _bookRepository.Setup(x => x.DeleteById(book)).Returns(async () => Task.FromResult(Books));
    }

    [Fact]
    public async Task Book_Add_Ok()
    {
        //setup
        var bookToAdd = new Book()
        {
            Id = new Guid("1c18f6ae-a16c-477e-b267-9184c4819742"),
            Title = "New Title",
            AuthorId = new Guid("dd9961d2-cab0-4bf5-9a9d-48862a64d63b"),
        };
        var expectedBookCount = 3;

        AuthorService.Setup(a => a.GetById(bookToAdd.AuthorId)).Returns(() => Task.FromResult(Authors.FirstOrDefault()));

        _bookRepository.Setup(x => x.GetAllByAuthorId(bookToAdd.AuthorId)).Returns(() =>
                    Task.FromResult(Books.Where(x => x.AuthorId == bookToAdd.AuthorId)));

        _bookRepository.Setup(x =>
            x.Add(It.IsAny<Book>()))
            .Callback(() =>
            {
                Books.Add(bookToAdd);
            }).Returns(Task.CompletedTask);

        //inject
        var service = new BookService(_bookRepository.Object, _authorService.Object);

        //Act
        await service.Add(bookToAdd);

        //Assert
        Assert.Equal(expectedBookCount, Books.Count);
        Assert.Equal(bookToAdd, Books.LastOrDefault());
    }

    [Fact]
    public async Task Book_Add_Author_Not_Found()
    {
        //setup
        var bookToAdd = new Book()
        {
            Id = new Guid("1c18f6ae-a16c-477e-b267-9184c4819742"),
            Title = "New Title",
            AuthorId = new Guid("dd9961d2-cab0-4bf5-9a9d-48862a64d63b"),
        };
        var expectedBookCount = 3;

        _authorService.Setup(a => a.GetById(bookToAdd.AuthorId)).Returns(() => Task.FromResult(Authors.FirstOrDefault(x=>x.bookToAdd.AuthorId)));

        _bookRepository.Setup(x => x.GetAllByAuthorId(bookToAdd.AuthorId)).Returns(() =>
                    Task.FromResult(Books.Where(x => x.AuthorId == bookToAdd.AuthorId)));

        _bookRepository.Setup(x =>
            x.Add(It.IsAny<Book>())
            

        //inject
        var service = new BookService(_bookRepository.Object, _authorService.Object);

        //Act
        await service.Add(bookToAdd);

        //Assert
        Assert.Equal(expectedBookCount, Books.Count);
        Assert.Null(result);
    }
}
