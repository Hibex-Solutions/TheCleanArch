// Copyright (c) The Clean Arch Project. All rights reserved.
// This file is a part of TheCleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

using TheCleanArch.Core.Patterns.GuardClauses;

namespace TheCleanArch.CoreTests.Patterns.GuardClauses;

[Trait("target", nameof(Guard))]
public class GuardTest
{
    [Fact(DisplayName = "NotNullArgument() raise exception when null value")]
    public void NotNullArgumentRaiseExceptionWhenNullValue()
    {
        var exception = Assert.Throws<ArgumentNullException>(
            () => _ = Guard.NotNullArgument<object>(null!, "value")
        );

        Assert.Equal("value", exception.ParamName);
    }

    [Fact(DisplayName = "NotNulArgument() accept not null values")]
    public void NotNullArgumentAcceptNotNull()
    {
        _ = Guard.NotNullArgument(new { }, "value");
    }

    [Fact(DisplayName = "NotNullArgument() returns same value")]
    public void NotNullArgumentReturnsSameValue()
    {
        var value1 = Guard.NotNullArgument(string.Empty, "value1");
        var value2 = new object();
        var value2Copy = Guard.NotNullArgument(value2, "value2");

        Assert.IsType<string>(value1);
        Assert.Empty(value1);
        Assert.Equal(value2, value2Copy);
        Assert.Equal(value2.GetHashCode(), value2Copy.GetHashCode());
    }

    [Fact(DisplayName = "NotEmptyArgument() raise exception when null value")]
    public void NotEmptyArgumentRaiseExceptionWhenNullValue()
    {
        var exception = Assert.Throws<ArgumentNullException>(
            () => _ = Guard.NotEmptyArgument<object[]>(null!, "value")
        );

        Assert.Equal("value", exception.ParamName);
    }

    [Fact(DisplayName = "NotEmptyArgument() reject empty value collection")]
    public void NotEmptyArgumentRejectEmptyCollection()
    {
        var exception1 = Assert.Throws<ArgumentOutOfRangeException>(
            () => _ = Guard.NotEmptyArgument(Array.Empty<object>(), "value1")
        );

        var exception2 = Assert.Throws<ArgumentOutOfRangeException>(
            () => _ = Guard.NotEmptyArgument(Array.Empty<string>(), "value2")
        );

        var exception3 = Assert.Throws<ArgumentOutOfRangeException>(
            () => _ = Guard.NotEmptyArgument(Array.Empty<int>(), "value3")
        );

        Assert.Equal("value1", exception1.ParamName);
        Assert.Equal("value2", exception2.ParamName);
        Assert.Equal("value3", exception3.ParamName);
    }

    [Fact(DisplayName = "NotEmptyArgument() returns same value")]
    public void NotEmptyArgumentReturnsSameValue()
    {
        var value1 = Guard.NotEmptyArgument("Initial value", "value");
        var value2 = new int[] { 1, 2, 3 };
        var value2Copy = Guard.NotEmptyArgument(value2, "value2");

        Assert.Equal("Initial value", value1);
        Assert.Equal(value2, value2Copy);
        Assert.Equal(value2.GetHashCode(), value2Copy.GetHashCode());
    }
}