﻿static class TextValidator
{
    public static void Validate(string value)
    {
        if (value.Length == 0)
        {
            throw new("Text length not be empty");
        }

        if (value.Length > 128)
        {
            throw new("Text length must be less than 128");
        }
    }
}