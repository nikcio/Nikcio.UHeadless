# Building Your Property Query

In GraphQL, queries are used to request specific data from a server. When building a property query in GraphQL, you can use fragments to organize and reuse common selections of fields. Fragments allow you to define a set of fields that can be included in multiple queries, reducing duplication and making queries more modular.

## Named properties (v4.1.0+)

Starting from version v4.1.0 it's possiable to query for named properties. This is done by using the `namedProperties` field. This field takes a list of property aliases that you want to fetch. This is useful when you want to fetch a specific set of properties and not all of them. The `namedProperties` field is available on all models that have properties. This includes content, media and member models. To query named properties you use the content, media or member types created in Umbraco. Example:

```graphql
query {
  contentAtRoot {
    nodes {
      namedProperties {
        ... on IMyContent {
          myProperty {
            value
          }
        }
      }
    }
  }
}
```

### Choosing the right interface to fetch properties

When building your named property query you need to choose the right interface to fetch the named properties from. This depends on the type of properties you want to fetch. In the API there a type based on all your content, media and member types but also also thier compositions. This means that if you have for example a Seo composition you can fetch properties based on that composition.

**When you have choosen the type you'd like to fetch on remember to place an `I` before the name. This will ensure that you can fetch the properties because the concrete types don't always return the expected vaules due to the implementation and the resrictions of GraphQL.**

Example:

```graphql
query {
  contentAtRoot {
    nodes {
      namedProperties {
        ... on IMyContentType {
          myProperty {
            value
          }
        }
        ... on IMyCompositionType {
          myCompositionProperty {
            value
          }
        }
      }
    }
  }
}
```

All properties match the models you can use on the other properties fields. This means that you can use the same fragments and queries as you would on the other properties fields. This is useful for especially the block list and block grid editors where you can go N-levels deep into the blocks. See the [fragments](#fragments) section for more information.

## Fragments

Fragments in GraphQL are reusable selections of fields that can be included in queries, mutations, or other fragments. They help simplify queries by abstracting common selections into separate units. Fragments enhance code reuse and maintainability by allowing you to define a set of fields once and include them in multiple queries.

When using fragments you can much more readable queries for content, media and member properties. Example:

```graphql
query {
  contentAtRoot {
    nodes {
      properties {
        alias
        value {
          ...propertyValues
        }
        editorAlias
      }
    }
  }
}
```

Here are some examples of fragments that you can use when building your property query:

## `propertyValues` Fragment

This fragment represents the all property editor fields for a `PropertyValue` object.

```graphql
fragment propertyValues on PropertyValue {
  ... propertyEditors
  ... blockEditor
  ... blockGridEditor
}
```

## `blockEditor` Fragment

This fragment represents the fields for a `BasicBlockListModel` object within a `PropertyValue`. In the first example we see how to fetch data for block lists going 1 level deep. In the other example we see how we can expand the fragment to go more levels deep into a block list.

Single level:

```graphql
fragment blockEditor on PropertyValue {
  ... on BasicBlockListModel {
    blocks {
      contentProperties {
        value {
          ...propertyEditors
        }
      }
      contentAlias
      settingsAlias
    }
  }
}
```

Multiple levels:

```graphql
fragment blockEditor on PropertyValue {
  ... on BasicBlockListModel {
    blocks {
      contentProperties {
        value {
          ...propertyEditors
          ... on BasicBlockListModel {
            blocks {
              contentProperties {
                value {
                  ...propertyEditors
                  ... on BasicBlockListModel {
                    blocks {
                      contentProperties {
                        value {
                          ...propertyEditors
                        }
                      }
                    }
                  }
                }
              }
            }
          }
        }
      }
      contentAlias
      settingsAlias
    }
  }
}
```

## `blockGridEditor` Fragment

This fragment represents the fields for a `BasicBlockGridModel` object within a `PropertyValue`. It includes grid columns, nested blocks, and their content and settings properties. In the same way block lists can be N-levels nested into itself the block grid editor can too. In this example we fetch data 2 levels deep. If you need to go deeper you want to query for the `blocks` section in the inner most `areas` property.

```graphql
fragment blockGridEditor on PropertyValue {
  ... on BasicBlockGridModel {
    gridColumns
    blocks {
      contentProperties {
        value {
          ...propertyEditors
        }
      }
      settingsProperties {
        value {
          ...propertyEditors
        }
      }
      columnSpan
      rowSpan
      areas {
        alias
        rowSpan
        columnSpan
        blocks {
          contentProperties {
            value {
              ...propertyEditors
            }
          }
          settingsProperties {
            value {
              ...propertyEditors
            }
          }
          columnSpan
          rowSpan
          areas {
            alias
            rowSpan
            columnSpan
          }
        }
      }
    }
  }
}
```

## `propertyEditors` Fragment

This fragment represents the simpler property editors that don't nest within them self like the block list and block grid. This will fetch the fields for a `PropertyValue` object, including the various property editors.

```graphql
fragment propertyEditors on PropertyValue {
  ...basicValue
  ...contentPicker
  ...dateTimePicker
  ...label
  ...mediaPicker
  ...memberPicker
  ...multiUrlPicker
  ...nestedContent
  ...richTextEditor
  ...unsupportedEditor
  model
}
```

## `basicValue` Fragment

This fragment represents the fields for a `BasicPropertyValue` object within a `PropertyValue`. It includes the basic value field. This will catch all property values that doesn't have a dedicated model for handling the querying. This includes for example the checklist editor and radio button editor. **Note that we here make use of the alias feature of GraphQL with the `basicValue: ` part of the fragment. This ensures that we don't have any clashing of models having a `value` field.**

```graphql
fragment basicValue on PropertyValue {
  ... on BasicPropertyValue {
    basicValue: value
  }
}
```

## `contentPicker` Fragment

This fragment represents the fields for a `BasicContentPicker` object within a `PropertyValue`. It includes the content list with its properties.

```graphql
fragment contentPicker on PropertyValue {
  ... on BasicContentPicker {
    contentList {
      id
      absoluteUrl
      key
      name
      url
      urlSegment
    }
  }
}
```

## `dateTimePicker` Fragment

This fragment represents the fields for a `BasicDateTimePicker` object within a `PropertyValue`. It includes the dateTime field.

```graphql
fragment dateTimePicker on PropertyValue {
  ... on BasicDateTimePicker {
    dateTime: value
  }
}
```

## `label` Fragment

This fragment represents the fields for a `BasicLabel` object within a `PropertyValue`. It includes the label field.

```graphql
fragment label on PropertyValue {
  ... on BasicLabel {
    label: value
  }
}
```

## `mediaPicker` Fragment

This fragment represents the fields for a `BasicMediaPicker` object within a `PropertyValue`. It includes the media items with their properties.

```graphql
fragment mediaPicker on PropertyValue {
  ... on BasicMediaPicker {
    mediaItems {
      id
      url
    }
  }
}
```

## `memberPicker` Fragment

This fragment represents the fields for a `BasicMemberPicker` object within a `PropertyValue`. It includes the members with their properties.

```graphql
fragment memberPicker on PropertyValue {
  ... on BasicMemberPicker {
    members {
      id
      name
      properties {
        alias
        value {
          ...memberPropertyEditors
        }
        editorAlias
      }
    }
  }
}
```

## `memberPropertyEditors` Fragment

This fragment represents the property editor fields for a `PropertyValue` object within a `MemberPicker` object.

```graphql
fragment memberPropertyEditors on PropertyValue {
  ...basicValue
  ...contentPicker
  ...dateTimePicker
  ...label
  ...mediaPicker
  ...slimMemberPicker
  ...multiUrlPicker
  ...nestedContent
  ...richTextEditor
  ...unsupportedEditor
  model
}
```

## `slimMemberPicker` Fragment

This fragment represents the fields for a `BasicMemberPicker` object within a `PropertyValue`. It includes the members without their properties.

```graphql
fragment slimMemberPicker on PropertyValue {
  ... on BasicMemberPicker {
    members {
      id
      name
    }
  }
}
```

## `multiUrlPicker` Fragment

This fragment represents the fields for a `BasicMultiUrlPicker` object within a `PropertyValue`. It includes the links with their properties.

```graphql
fragment multiUrlPicker on PropertyValue {
  ... on BasicMultiUrlPicker {
    links {
      name
      target
      type
      url
    }
  }
}
```

## `nestedContent` Fragment

This fragment represents the fields for a `BasicNestedContent` object within a `PropertyValue`. It includes the elements with their properties.

```graphql
fragment nestedContent on PropertyValue {
  ... on BasicNestedContent {
    elements {
      properties {
        alias
        value {
          ...nestedContentPropertyEditors
        }
        editorAlias
      }
    }
  }
}
```

## `nestedContentPropertyEditors` Fragment

This fragment represents the property editor fields for a `PropertyValue` object within a `NestedContent` object.

```graphql
fragment nestedContentPropertyEditors on PropertyValue {
  ...basicValue
  ...contentPicker
  ...dateTimePicker
  ...label
  ...mediaPicker
  ...slimMemberPicker
  ...multiUrlPicker
  ...richTextEditor
  ...unsupportedEditor
  model
}
```

## `richTextEditor` Fragment

This fragment represents the fields for a `BasicRichText` object within a `PropertyValue`. It includes the richText and sourceValue fields.

```graphql
fragment richTextEditor on PropertyValue {
  ... on BasicRichText {
    richText: value
    sourceValue
  }
}
```

## `unsupportedEditor` Fragment

This fragment represents the fields for a `BasicUnsupportedPropertyValue` object within a `PropertyValue`. It includes the message field.

```graphql
fragment unsupportedEditor on PropertyValue {
  ... on BasicUnsupportedPropertyValue {
    message
  }
}
```

## Conflicting property names
In the case you have Conflicting property names on your properties you may need to use aliases to fetch the data you need.

Example:
```graphql
query {
  contentAtRoot {
    nodes {
      properties {
        value {
          ...on BasicPropertyValue {
            value
          }
          ...on BasicRichText {
            text: value
            sourceValue
          }
        }
      }
    }
  }
}
```

Here the `BasicRichText` value property conflicts with the `BasicPropertyValue` value property so it's renamed to `text`.