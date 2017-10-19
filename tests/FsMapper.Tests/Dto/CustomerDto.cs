using System;

namespace FsMapper.Tests.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public bool IsDeleted { get; set; }
    }
}