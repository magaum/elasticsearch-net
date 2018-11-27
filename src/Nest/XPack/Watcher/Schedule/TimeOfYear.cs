﻿using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Nest
{
	[DataContract]
	[ReadAs(typeof(TimeOfYear))]
	public interface ITimeOfYear
	{
		[DataMember(Name ="at")]
		[JsonConverter(typeof(ReadSingleOrEnumerableJsonConverter<string>))]
		IEnumerable<string> At { get; set; }

		[DataMember(Name ="int")]
		[JsonConverter(typeof(ReadSingleOrEnumerableJsonConverter<Month>))]
		IEnumerable<Month> In { get; set; }

		[DataMember(Name ="on")]
		[JsonConverter(typeof(ReadSingleOrEnumerableJsonConverter<int>))]
		IEnumerable<int> On { get; set; }
	}

	public class TimeOfYear : ITimeOfYear
	{
		public IEnumerable<string> At { get; set; }
		public IEnumerable<Month> In { get; set; }

		public IEnumerable<int> On { get; set; }
	}

	public class TimeOfYearDescriptor : DescriptorBase<TimeOfYearDescriptor, ITimeOfYear>, ITimeOfYear
	{
		IEnumerable<string> ITimeOfYear.At { get; set; }
		IEnumerable<Month> ITimeOfYear.In { get; set; }
		IEnumerable<int> ITimeOfYear.On { get; set; }

		public TimeOfYearDescriptor In(IEnumerable<Month> @in) => Assign(a => a.In = @in);

		public TimeOfYearDescriptor In(params Month[] @in) => Assign(a => a.In = @in);

		public TimeOfYearDescriptor On(IEnumerable<int> on) => Assign(a => a.On = on);

		public TimeOfYearDescriptor On(params int[] on) => Assign(a => a.On = on);

		public TimeOfYearDescriptor At(IEnumerable<string> time) => Assign(a => a.At = time);

		public TimeOfYearDescriptor At(params string[] time) => Assign(a => a.At = time);
	}
}
