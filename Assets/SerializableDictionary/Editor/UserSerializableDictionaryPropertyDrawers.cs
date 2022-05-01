using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;

using CraftSurvival.Contents;

[CustomPropertyDrawer(typeof(StringTileDictionary))]
public class AnySerializableDictionaryPropertyDrawer : SerializableDictionaryPropertyDrawer {}

//[CustomPropertyDrawer(typeof(ColorArrayStorage))]
public class AnySerializableDictionaryStoragePropertyDrawer: SerializableDictionaryStoragePropertyDrawer {}
