﻿namespace UnionArchitecture.Aplication.DTOs.Blog;

public record BlogCreateDTO(string imagePath, string title, string description, BlogImageGetDTO BlogImageGetDTO);