# Changelog

All notable changes to this project will be documented in this file. See [standard-version](https://github.com/conventional-changelog/standard-version) for commit guidelines.

## [2.0.1](https://github.com/nikcio/Nikcio.UHeadless/compare/v2.0.0-preview.3...v2.0.1) (2022-05-04)


### Dependencies

* Updated dependencies

## [2.0.0](https://github.com/nikcio/Nikcio.UHeadless/compare/v2.0.0-preview.3...v2.0.0) (2022-05-01)


### Features

* Add id to media picker item ([#43](https://github.com/nikcio/Nikcio.UHeadless/issues/43)) ([eb9e40d](https://github.com/nikcio/Nikcio.UHeadless/commit/eb9e40d184aeb69bfe14dd01560c0d606209445f))

## [2.0.0-preview.3](https://github.com/nikcio/Nikcio.UHeadless/compare/v2.0.0-preview.2...v2.0.0-preview.3) (2022-04-26)


### Bug Fixes

* Added correct alias to block list ([fa026bf](https://github.com/nikcio/Nikcio.UHeadless/commit/fa026bf92bc55068d1a01052f8f72fc4c4f7803c))

## [2.0.0-preview.2](https://github.com/nikcio/Nikcio.UHeadless/compare/v2.0.0-preview.1...v2.0.0-preview.2) (2022-04-26)


### ⚠ BREAKING CHANGES

* BasicMediaItem --> BasicMediaPickerItem
MediaItem -- MeidaPickerItem
BasicMemberItem --> BasicMemberPickerItem
MemberItem --> MemberPickerItem
BasicLinkItem --> BasicMultiUrlPickerItem
LinkItem --> MultiUrlPickerItem
* BasicMember --> BasicMemberItem
CreteMember --> CreateMemberPickerItem
Member --> MemberItem
CreateLink --> CreateLinkPickerItem
BasicLink ..> BasicLinkItem
Link --> LinkItem

### Features

* Added editor alias to BasicBlockListModel ([da7c885](https://github.com/nikcio/Nikcio.UHeadless/commit/da7c885943bccc27f78ae37d68ee1c24728d5398))
* Added generic media picker ([811295a](https://github.com/nikcio/Nikcio.UHeadless/commit/811295a56a99930f0fdc9375dc420640a5951245))
* Added generic member picker ([c6597a3](https://github.com/nikcio/Nikcio.UHeadless/commit/c6597a38b4c18bac81828687c49fcea7722ff1cd))
* Added generic models for multi url picker ([befc3ab](https://github.com/nikcio/Nikcio.UHeadless/commit/befc3abc0b82884b698c1a426eb5468cc6b7affa))
* Added generic models to content picker ([4e1fa3b](https://github.com/nikcio/Nikcio.UHeadless/commit/4e1fa3b02bc50c9d4a49614d58dad0d4c03f20f7))


### Bug Fixes

* Fixed creation of link item ([55b3052](https://github.com/nikcio/Nikcio.UHeadless/commit/55b3052c3173062c385314edca0469f0ad68f7cb))
* Made methods virtual ([d558c18](https://github.com/nikcio/Nikcio.UHeadless/commit/d558c18c1b1de5d8984f543dbdde656e3b52874a))


* Changed naming of picker models to have similar naming ([3dbbc43](https://github.com/nikcio/Nikcio.UHeadless/commit/3dbbc43f8c656adda4553f15d0f390f6ced92bee))
* Changed picker model naming ([a9727d9](https://github.com/nikcio/Nikcio.UHeadless/commit/a9727d92d08537ccdb4f3aac2a34a919548b3ea6))

## [2.0.0-preview.1](https://github.com/nikcio/Nikcio.UHeadless/compare/v2.0.0-preview.0...v2.0.0-preview.1) (2022-04-24)


### Features

* Add query by content type and filters to children ([#36](https://github.com/nikcio/Nikcio.UHeadless/issues/36)) ([9467bc5](https://github.com/nikcio/Nikcio.UHeadless/commit/9467bc54653d86dbb687e00af9bfcc5e12310d07)) Thanks @Rizzet

### Dependencies

* Updated dependencies

## [2.0.0-preview.0](https://github.com/nikcio/Nikcio.UHeadless/compare/v1.3.0...v2.0.0-preview.0) (2022-04-14)


### ⚠ BREAKING CHANGES

* New naming scheme rules:
All presets are prefixed with `Basic`.
Removed the `GraphType` part of classes as it made little sense.
Bases are now named in simple form. For example `PropertyValueBaseGraphType` --> `PropertyValue`

New naming of classes:

Maps:
BaseMap --> DictionaryMap

Content:
ContentGraphType --> BasicContent
IContentGraphTypeBase --> IContent

Content queries:
ContentQuery --> BasicContentQuery
ContentQueryBase --> ContentQuery

Content types:
ContentTypeGraphType --> ContentType

Elements:
ElementGraphType --> BasicElement
IElementGraphTypeBase --> IElement

Properties:
PropertyValueBaseGraphType --> PropertyValue
BlockListItemGraphType --> BasicBlockListItem
BlockListItemBaseGraphType --> BlockListItem
BlockListModelGraphType --> BasicBlockListModel
ContentPickerGraphType --> BasicContentPicker
ContentPickerItemGraphType --> BasicContentPickerItem
PropertyValueBasicGraphType --> BasicPropertyValue
MediaItem --> BasicMediaItem
MediaPickerGraphType --> BasicMediaPicker
MemberGraphType --> BasicMember
MemberPickerGraphType --> BasicMemberPicker
LinkGraphType --> BasicLink
MultiUrlPickerGraphType --> BasicMultiUrlPicker
ElementBaseGraphType --> NestedContentElement
NestedContentElementGraphType --> BasicNestedContentElement
NestedContentGraphType --> BasicNestedContent
RichTextEditorGraphType --> BasicRichText
IPropertyGraphTypeBase --> IProperty
PropertyGraphType --> BasicProperty

Property queries:
PropertyQuery --> BasicPropertyQuery
PropertyQueryBase --> PropertyQuery

Property types:
IPropertyTypeGraphType --> IPropertyType

Media:
IMediaGraphTypeBase --> IMedia
MediaGraphType --> BasicMedia

Media queries:
MediaQuery --> BasicMediaQuery
MediaQueryBase --> MediaQuery
* Changed parameters for most extensions to use option classes for the available options.
* Automapper was removed
* .Net 5 is no longer supported

### Features

* Created more developer friendly options to UHeadless extensions ([25b9dc6](https://github.com/nikcio/Nikcio.UHeadless/commit/25b9dc6a306d9b587435904dbbacde9a79534856))
* Removed Automapper ([349d148](https://github.com/nikcio/Nikcio.UHeadless/commit/349d148166292aad058d11030f73334dcfa29203))
* Steamline flow and models ([#35](https://github.com/nikcio/Nikcio.UHeadless/issues/35)) ([f2efc27](https://github.com/nikcio/Nikcio.UHeadless/commit/f2efc2798b212f1df99d9a9ad90ef74c1767286f))
* Updated names to be more clear and easier to remember ([2e6ff82](https://github.com/nikcio/Nikcio.UHeadless/commit/2e6ff8214485faf0320ddb3b4b829dc2c7fb718e))
* Updated to .Net 6 ([6aafada](https://github.com/nikcio/Nikcio.UHeadless/commit/6aafada3b88bc0a87bc08ffaa7b689007e1f19ff))


### Bug Fixes

* **deps:** Removed unnecessary dependencies ([f82feaf](https://github.com/nikcio/Nikcio.UHeadless/commit/f82feaf713b72206d9a8aa3aed536e4b6196299a))

## [1.3.0](https://github.com/nikcio/Nikcio.UHeadless/compare/v1.2.0...v1.3.0) (2022-03-05)


### Features

* Added media queries ([dd4c079](https://github.com/nikcio/Nikcio.UHeadless/commit/dd4c0799fe2cebf38fda73fe91c76665c972e6a9))
* Added XML docs & nullable ([98eb8d8](https://github.com/nikcio/Nikcio.UHeadless/commit/98eb8d8556c4bd9ab0ed57232085b6363509cee8))

## [1.2.0](https://github.com/nikcio/Nikcio.UHeadless/compare/v1.1.0...v1.2.0) (2022-03-01)


### Features

* Added virtual to all public methods ([03d400a](https://github.com/nikcio/Nikcio.UHeadless/commit/03d400a92f48469ef7f6902eb3d7078c0f914a1e))

## [1.1.0](https://github.com/nikcio/Nikcio.UHeadless/compare/v1.0.0...v1.1.0) (2022-02-26)


### Features

* Added customizable queries & return types ([707843e](https://github.com/nikcio/Nikcio.UHeadless/commit/707843e90e0a0b10eb166c154d8137b297ad76fc))

## [1.0.0](https://github.com/nikcio/Nikcio.UHeadless/compare/v0.1.7...v1.0.0) (2022-02-06)


### ⚠ BREAKING CHANGES

* This changed almost all namespaces.
* Updated the naming of the queries to include what is being queried.

Example:
To get content at root you previously used atRoot this is now contentAtRoot

List:
atRoot --> contentAtRoot
byId --> contentById
byGuid --> contentByGuid
atRoute --> contentAtRoute

New:
propertiesAtRoute
propertiesById
propertiesByGuid

The new queries uses the same values for fetching properties but gives an eaiser way to do filtering, paging and sorting.

### Features

* Added HotChocolate.Data ([6eb7c67](https://github.com/nikcio/Nikcio.UHeadless/commit/6eb7c67e99de869db4ba42d4ffceb0457773d707))
* Added InitializeOnStartup to improve startup performance ([c4fa00f](https://github.com/nikcio/Nikcio.UHeadless/commit/c4fa00fa87b30d17b6d801a6a1c74b34edb830e7))
* Added option to throw on schema error ([519b89d](https://github.com/nikcio/Nikcio.UHeadless/commit/519b89d8b2944ac8931ef714cf76dc90b1f5b536))
* Added Paging, Filtering & Sorting ([8fe4483](https://github.com/nikcio/Nikcio.UHeadless/commit/8fe4483607c002a9baa732fd3b915f9afa682ff0))
* Added support for Media Picker ([e0ea5b8](https://github.com/nikcio/Nikcio.UHeadless/commit/e0ea5b8462c9763adf4b52d406dda24bf3d3c14f))
* Added Tracing option ([b083bc3](https://github.com/nikcio/Nikcio.UHeadless/commit/b083bc34efb5a2a8e5778c25b645d6afbd06b98e))
* Updated HotChocolate.AspNetCore to 12.6.0 ([667af04](https://github.com/nikcio/Nikcio.UHeadless/commit/667af041c0e830b95e25aaeede7f0167a66bf25e))


### Bug Fixes

* Added PropertyRepository to DI ([fa4382f](https://github.com/nikcio/Nikcio.UHeadless/commit/fa4382f8b8b0c41e35eda9710d82f2b4b752159e))
* Changes to improve code quality ([03db2cb](https://github.com/nikcio/Nikcio.UHeadless/commit/03db2cb0e93bb186520427b5a2def32b662a4d3c))
* Fixed filtering on ContentType, Key and Properties ([76edfe5](https://github.com/nikcio/Nikcio.UHeadless/commit/76edfe59f0b1345058a4ae60cb2b6661363fd77d))
* Fixed tracing option ([7bda7b1](https://github.com/nikcio/Nikcio.UHeadless/commit/7bda7b1909907385824222cb0aa73f668bc609f4))


* !refactor: Moved into feature code structure ([9645a32](https://github.com/nikcio/Nikcio.UHeadless/commit/9645a32e15449fe4de6435f02c4a124273f236a9))
* !feat: Added seperate property queries ([26e41b9](https://github.com/nikcio/Nikcio.UHeadless/commit/26e41b915875894d50a82eb53ec2f71bdb6240d3))

### [0.1.7](https://github.com/nikcio/Nikcio.UHeadless/compare/v0.1.6...v0.1.7) (2022-02-05)


### Features

* Added Cors options to the startup extension ([0c087d7](https://github.com/nikcio/Nikcio.UHeadless/commit/0c087d7fcbf9c5bba45fdec6563611f205c7dd73))


### Bug Fixes

* Made Cors option optional ([5cdebbc](https://github.com/nikcio/Nikcio.UHeadless/commit/5cdebbc6d63b84be95ec6541a40adb842ce310b5))

### [0.1.6](https://github.com/nikcio/Nikcio.UHeadless/compare/v0.1.5...v0.1.6) (2022-02-05)


### Bug Fixes

* Removed type property ([4307261](https://github.com/nikcio/Nikcio.UHeadless/commit/430726115b075efa39b588dca6775fccb7342384))

### [0.1.5](https://github.com/nikcio/Nikcio.UHeadless/compare/v0.1.4-beta...v0.1.5) (2022-02-04)


### Features

* Added Content Picker model ([432b71f](https://github.com/nikcio/Nikcio.UHeadless/commit/432b71f840a12b80ae062e7107e2c3685420c122))
* Added Member graph model ([c52a73b](https://github.com/nikcio/Nikcio.UHeadless/commit/c52a73bd97b49898f54b5b789f4cc061ebd4b303))
* Added MultiNodeTreePicker support ([82f0602](https://github.com/nikcio/Nikcio.UHeadless/commit/82f060296490ad46a623d2757a2fc23df412f7a5))
* Added MultiUrlPicker model ([f698814](https://github.com/nikcio/Nikcio.UHeadless/commit/f698814b6b8a1180cb3adb23715be4061614ba53))
* Made properties read-only on content ([a6443a3](https://github.com/nikcio/Nikcio.UHeadless/commit/a6443a34e238aba996ba821fdcc746312d38c978))


### Bug Fixes

* Fixed MultiUrlPicker initial value ([03bdc89](https://github.com/nikcio/Nikcio.UHeadless/commit/03bdc896d1cfd4378297ee13e945adf617699418))
* Fixed property map implementation ([564a6a8](https://github.com/nikcio/Nikcio.UHeadless/commit/564a6a87b4e6aab51fe3931a14fd569933940bf8))
* Fixed PropertyMap defaults and custom mappings ([f0b98f4](https://github.com/nikcio/Nikcio.UHeadless/commit/f0b98f4d64bde9cd366a6a6604af9a717d060dee))

### [0.1.4](https://github.com/nikcio/Nikcio.UHeadless/compare/v0.1.3-beta...v0.1.4) (2022-01-27)


### Features

* Added support for Rich text editor ([67db76d](https://github.com/nikcio/Nikcio.UHeadless/commit/67db76db6f1ccc499f709fe1ce515ff7a6d6cbe2))


### Bug Fixes

* Fixed automapper error when fetching content ([bb51076](https://github.com/nikcio/Nikcio.UHeadless/commit/bb51076ebb97e8687a0564b79d389062b88f35f8))
* Fixed children fetching ([8f79eb7](https://github.com/nikcio/Nikcio.UHeadless/commit/8f79eb7651d6422b6fcf5041fdd0dabb487d4212))

### [0.1.3](https://github.com/nikcio/Nikcio.UHeadless/compare/v0.1.2...v0.1.3) (2022-01-27)


### Features

* Added automapper extension method ([bef3476](https://github.com/nikcio/Nikcio.UHeadless/commit/bef34764f22bce9579d6a96439cad39e83b8240d))
* Added depencency reflector factory ([db8236b](https://github.com/nikcio/Nikcio.UHeadless/commit/db8236b498692367b5a0984cca9b969e9952bbe6))
* Block list & Nested content can now use any type ([a4585d0](https://github.com/nikcio/Nikcio.UHeadless/commit/a4585d0a382803d2e39153f2e361001458dee7d3))


### Bug Fixes

* Added required constructor to PropertyValueBaseGraphType ([9d7e12a](https://github.com/nikcio/Nikcio.UHeadless/commit/9d7e12a3b10e9a141b30a98a2e08658ce3eb7f62))
* Added support for Umbraco v9 ([977b237](https://github.com/nikcio/Nikcio.UHeadless/commit/977b237904dab5460208ca4a592cf3ca2065e53a))
* Made culture and content available on CreateProperty ([eb10b59](https://github.com/nikcio/Nikcio.UHeadless/commit/eb10b59a362f45007393ec994f757b27f8a047a6))

### 0.1.2 (2022-01-25)


### Features

* Added DI to property value generation ([c8f6705](https://github.com/nikcio/Nikcio.Umbraco.Headless/commit/c8f67056b5c29a6d7ea24d48bf0ab632f3de5c52))
* Added nested content support & Added properties to block list ([ef655e9](https://github.com/nikcio/Nikcio.Umbraco.Headless/commit/ef655e9480ba7ad3ed7c9891df1c3140a8378b90))
* Added property value mapping options ([1ff1112](https://github.com/nikcio/Nikcio.Umbraco.Headless/commit/1ff1112a2e326bd247eaeb96450aecef31514efe))
* Added standard-version ([48be288](https://github.com/nikcio/Nikcio.Umbraco.Headless/commit/48be2889f41d0ada781292486a05daef7aaf4ef7))
* Added the abillity to fetch properties ([d5d83d8](https://github.com/nikcio/Nikcio.Umbraco.Headless/commit/d5d83d8e8411973ddf7209826007cab8f433da7d))
* Content fetching 1.0 ([eb8177f](https://github.com/nikcio/Nikcio.Umbraco.Headless/commit/eb8177f7291cb22b09d583407343b10d72f2032a))
* Created extensions for startup ([76290a0](https://github.com/nikcio/Nikcio.Umbraco.Headless/commit/76290a0dca7b2f6295accc0d36272369fbef302b))
* Renamed project ([bd62b60](https://github.com/nikcio/Nikcio.Umbraco.Headless/commit/bd62b6062e7e4f5fad0d0222489808c74f71c3a9))
