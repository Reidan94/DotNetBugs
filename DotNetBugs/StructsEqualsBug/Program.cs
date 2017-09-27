using System;

namespace StructsEqualsBug
{
  static class Program
  {
    struct LongStruct
    {
      long X;

      public override bool Equals(object obj)
      {
        return false;
      }

      public override int GetHashCode()
      {
        return 0;
      }
    }

    struct ByteStruct
    {
      byte X;

      public override bool Equals(object obj)
      {
        return false;
      }

      public override int GetHashCode()
      {
        return 0;
      }      
    }

    struct LongStructContainer
    {
      LongStruct A;
    }

    struct ByteStructContainer
    {
      ByteStruct A;
    }

    static void Main()
    {
      var longStruct = new LongStructContainer();
      var byteStruct = new ByteStructContainer();

      Console.WriteLine(byteStruct.Equals(byteStruct));
      Console.WriteLine(longStruct.Equals(longStruct));
      Console.ReadLine();
    }
  }
}
