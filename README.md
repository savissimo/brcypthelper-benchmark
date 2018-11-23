# BCryptHelper Benchmark

A small console utility to benchmark the BCrypt encryption algorithm. 

## What is BCrypt (in a few words)

BCrypt is an encryption algorithm. It is based on Blowfish and revolves around encoding the payload with Blowfish multiple times, salting it every time. 

If you want to learn more about BCrypt, a good starting point is [Wikipedia](https://en.wikipedia.org/wiki/Bcrypt).

It is very used for storing passwords, because it is a valid way to create a one-way hash. 

## What's the use of a benchmark? Shouldn't I use a library that someone else developed? Do I really need this?

The main advantage of BCrypt is its iterational nature makes it slow, which is good when you want to stop (or rather hinder) a brute-force attacker. Not only that, but we can make it *as slow as we want* by setting a **work factor**, i.e., a number that determines how many iterations will be used. 

There's no universally good work factor. What used to be (reasonably) safe in 2009 (when BCrypt was first developed) is now a rather low value, because of the higher performance of more recent computers. What you should aim for is a work factor that satisfies two criteria:
1. legitimate procedures should not take too much time: for example, a user logging in may not notice a delay of half a second, but will not be happy to wait several seconds;
2. malicious attacks instead should be as slow as possible, so that the attempt rate of a brute-force algorithm makes the attack harder to afford. 

Note that using good salts (such as automatically generated ones) is a strong measure against dictionary- and lookup-based attacks, so the main concern is brute-force attacks. 

To choose the work factor that fits for you, you need to check how much it takes *on your machine* (on your *production* machine) to run the encryption with a given work factor. The ideal time is something you decide, but a good suggestion is to aim for something between 150 and 400 milliseconds. 

## Usage

Simply run the executable to see a table with the work factors (from 4 to 20) and the time taken. 

The time taken is measured by running 100 test encryptions, and taking an average time. A higher number of tests makes the average more stable, but makes the measurement take longer. You can change this value with the `--tests <num>` command line parameter. 

## Details and libraries used

There are two versions included: one is for .NET Framework (4.7.2) and the other one is for .NET Core (2.1). Use the one that matches your project. 

The .NET Framework version uses the [BCrypt NuGet package](https://www.nuget.org/packages/BCrypt/1.0.0) by [fvilers](https://www.nuget.org/profiles/fvilers). 

The .NET Core version uses the [Bcrypt-Core NuGet package](https://www.nuget.org/packages/BCrypt-Core/2.0.0) by [Haryon Caetano](https://www.nuget.org/profiles/haryoncaetano). You can find more about his project on [GitHub](https://github.com/haryoncaetano/bcrypt-core). 

Thanks to both the authors for their work!
