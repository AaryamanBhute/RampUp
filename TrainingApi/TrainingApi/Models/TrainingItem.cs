using System;

namespace TrainingApi.Models
{
	public class TrainingItem
	{
		public long Id { get; set; }
		public string? Query { get; set; }
		public string? Response { get; set; }
		public long Timestamp { get; set; }
		public bool completed { get; set; }
	}
}

