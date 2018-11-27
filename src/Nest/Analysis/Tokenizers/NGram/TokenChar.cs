using System.Runtime.Serialization;

namespace Nest
{
	public enum TokenChar
	{
		[EnumMember(Value = "letter")]
		Letter,

		[EnumMember(Value = "digit")]
		Digit,

		[EnumMember(Value = "whitespace")]
		Whitespace,

		[EnumMember(Value = "punctuation")]
		Punctuation,

		[EnumMember(Value = "symbol")]
		Symbol,
	}
}
