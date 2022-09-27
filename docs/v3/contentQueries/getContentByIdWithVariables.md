For example,in Umbraco, our page id is 1120

We create the variable

{
  "contentid":1120
}

Then the GraphQL query will be

query($contentid: Int!){
  contentById(id: $contentid) {
    id
    name
    templateId
    creatorId
    itemType
    writerId
    key
    url
    properties {
      editorAlias
      alias
      value {
        ... on BasicPropertyValue {
          value
        }
        ... on BasicMediaPicker {
          mediaItems {
            url
            id
          }
        }
        ... on BasicBlockListModel {
          alias
        }
      }
    }
  }
}

<img width="928" alt="image" src="https://user-images.githubusercontent.com/661517/192493289-454eb475-e6e2-45fc-b4eb-b79a8251948f.png">
