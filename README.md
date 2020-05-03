# VoltFramework 
VoltFramework is a advanced framework for creating programming language. Got Linking,Encrypting,Parsing,Lexing,Interpriting,Compiling tools.

Modules: Linker, Crypto, IO, Memory, LanguageTools, LanguageToolsX

## VoltFramework.Linker
Linker is a tool to combine a bunch of files/strings to one file/string.Linkers is used in programming languages,to link all code files to one. Linker in our framework is has all required functions for linking,unlinking files or strings. Linked or Unlinked file/string can be automatically encrypted/decrypted.

## VoltFramework.Crypto
Easy encryption/decryption of strings with keys. Easy-to-use and fast methods.

## VoltFramework.LanguageTools (LT)
soon... 
## VoltFramework.LanguageToolsX (LTX)
soon... 
## VoltFramework.PremiumLanguageTools (PLT) 
soon... 
# Comparing LT & LTX

|Feature          | LT  | LTX |
|:---------------:|:---:|:---:|
|Basic Parsing    | Yes | Yes |
|Multiline Parsing| No  | Yes |
|Custom Separators| Yes | No  |
|Basic Lexing     | Yes | Yes |
|Multiline Lexing | No  | Yes |
|Minimum lines of code| 50 | 6 |
|Decryption support| No | Yes |
|Custom Token Check| No | Yes |
|.NET Compilation | No  | Yes |
|Native Compilation|No  | Soon|
|Token Parsing    | Yes | Yes |

# Creating Programming Language with LT
soon... 

# Creating Programming Language with LTX
Creating programming language with LTX module is a more easier and less complicated.LTX has `LanguageDescriber` class,that used to handle Lexer,Parser for the language.So,lets see how to create a programming language:
```cs
            string code = "print('hello world')";

            StringParser sp = new StringParser(new string[] { "(", ")", ";", ",", "{", "}" });
            Lexer l = new Lexer();
            Parser p = new Parser();

            LanguageDescriber d = new LanguageDescriber(l, p, sp);
            d.DoExecuting();
```
