# CustomComboCN

此插件旨在将连击和互相关联的能力技合并到一个按键上，感谢 [daemitus](https://github.com/attickdoor/XIVComboPlugin)  和 [attickdoor](https://github.com/daemitus/XIVComboPlugin) 的工作，他们实现了最初的基础功能，使得此插件的功能得以实现。
此仓库专注于降低身为国服玩家的开发维护人员的开发体验，并且使得合作开发更为简单方便。

## 开发

首先在根目录创建一个名为`sdk`的文件夹，然后将獭爹的`Dalamud.Updater`下载的运行时文件夹内的所有文件放到`sdk`目录下。
在`powershell`或`cmd`下运行`debug.bat`，你会在根目录的`build/debug`路径找到生成的dll。

### 开发一个新的combo

每一个职业combo的源码都存放在`src/Combos/${JobName}`目录下，其中`Adventurer`意味“冒险者”，是特殊的职业，特指多个职业都能生效的combo，比如即刻复活。
所有的combo都派生自`CustomCombo`基类，同时需要打上命名空间`CustomComboPlugin.Attributes`下的各种`Attribute`来标识combo的特征，各种`Attribute`的作用如下：

1. **CustomComboInfo**  
   最重要的`Attribute`，标识了combo的基本信息
   - `Name`  
   combo的名字，显示在配置界面上
   - `Description`  
   combo的介绍，尽可能的清晰易懂的介绍combo的功能
   - `JobId`  
   combo对应的职业Id，作为常量可以在`CustomComboPlugin.Job`类中找到
   - `ComboId`  
   combo的Id，也是唯一标识符，`ushort`类型。为了避免冲突以及对其他开发人员透明，建议此Id采用常量表达式的方式声明在子类，其中高8位固定为职业Id，低8位可以自定义。比如即刻复活的Id：`public const ushort Identity = (Job.Adventurer << 8) ^ 0x10;`
   - `Order`  
   combo在配置界面的排序，同时也是combo逻辑的执行顺序
2. **SecretCombo**  
   秘密combo，需要用户手动勾选特定选项才会在配置界面显示，一般来说，如果你认为此combo需要额外的游戏理解才需要使用时，可以给combo加上此`Attribute`
3. **ConflictCombo**  
   与其他combo冲突。此`Attribute`可以附加多个，标识与多个combo之间互相冲突。此`Attribute`仅在配置界面单向生效，如果A和B两个combo互相冲突，需要两者都打上此`Attribute`并且初始化为对方的ComboId，如果一个combo与另一个combo冲突，那么在用户勾选此combo时会取消勾选冲突的combo。因为会引入额外的复杂度，不建议大量开发互相冲突的combo
4. **ParentCombo**  
   是某个combo的子combo，只有当父combo生效时此combo才会正常运行时，可以给combo加上此`Attrbute`，注意，为了降低复杂度，一个combo最多只能有一个父combo
5. **ObsoluteCombo**  
   过期的combo，如果一个combo因为版本更新而失效，开发人员没有精力及时维护，可以将combo标记为过期，注意，如果父combo被标记为过期，子combo也需要标记为过期，否则可能会出现未定义行为。

combo代码的编写需要尽可能的以简单清晰为主，在没有必要的情况下，请勿过度优化并使代码丧失可读性。魔术数请务必声明为常量。