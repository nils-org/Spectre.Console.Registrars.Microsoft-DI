# Spectre.Console.Registrars.Microsoft-DI

[![standard-readme compliant][]][standard-readme]
[![Contributor Covenant][contrib-covenantimg]][contrib-covenant]
[![Build][githubimage]][githubbuild]
[![Codecov Report][codecovimage]][codecov]
[![NuGet package][nugetimage]][nuget]

An implementation of an ITypeRegistrar for Spectre.Console using Microsoft.Extensions.DependencyInjection

## Table of Contents

- [Install](#install)
- [Usage](#usage)
- [Maintainer](#maintainer)
- [Contributing](#contributing)
- [License](#license)

## Install

```ps
Install-Package Spectre.Console.Registrars.Microsoft-Di
```

## Usage

```
var collection = new ServiceCollection();
// setup your end of the ServiceCollection...
var registrar = new ServiceCollectionRegistrar(collection);
var app = new CommandApp(registrar);
```

## Maintainer

[Nils Andresen @nils-a][maintainer]

## Contributing

Spectre.Console.Registrars.Microsoft-Di follows the [Contributor Covenant][contrib-covenant] Code of Conduct.

We accept Pull Requests.

Small note: If editing the Readme, please conform to the [standard-readme][] specification.

## License

[MIT License © Nils Andresen][license]

[githubbuild]: https://github.com/nils-org/Spectre.Console.Registrars.Microsoft-Di/actions/workflows/build.yml?query=branch%3Adevelop
[githubimage]: https://github.com/nils-org/Spectre.Console.Registrars.Microsoft-Di/actions/workflows/build.yml/badge.svg?branch=develop
[codecov]: https://codecov.io/gh/nils-org/Spectre.Console.Registrars.Microsoft-Di
[codecovimage]: https://img.shields.io/codecov/c/github/nils-org/Spectre.Console.Registrars.Microsoft-Di.svg?logo=codecov&style=flat-square
[contrib-covenant]: https://www.contributor-covenant.org/version/2/0/code_of_conduct/
[contrib-covenantimg]: https://img.shields.io/badge/Contributor%20Covenant-v2.0%20adopted-ff69b4.svg
[maintainer]: https://github.com/nils-a
[nuget]: https://nuget.org/packages/Spectre.Console.Registrars.Microsoft-Di
[nugetimage]: https://img.shields.io/nuget/v/Spectre.Console.Registrars.Microsoft-Di.svg?logo=nuget&style=flat-square
[license]: LICENSE.txt
[standard-readme]: https://github.com/RichardLitt/standard-readme
[standard-readme compliant]: https://img.shields.io/badge/readme%20style-standard-brightgreen.svg?style=flat-square
[documentation]: https://nils-org.github.io/Spectre.Console.Registrars.Microsoft-Di/
[api]: https://cakebuild.net/api/Cake.SevenZip/