using System;
using Challenge03.Dtos;
using Challenge03.Entity;

namespace Challenge03.Mapping;

public static class CategoryMapping
{
      public static CategoryDto ToDto(this CategoryEntity category){
        return new CategoryDto(category.Id, category.Name);

    }

}
