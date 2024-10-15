# 创建和嵌套组件 
React 应用程序是由 组件 组成的。一个组件是 UI（用户界面）的一部分，它拥有自己的逻辑和外观。组件可以小到一个按钮，也可以大到整个页面。
```js
function MyButton() {
  return (
    <button>I'm a button</button>
  );
}

export default function MyApp() {
    return (
        <div>
            <h1>Welcome to my app</h1>
            <MyButton /> //
        </div>
    );
}
```
> React 组件必须以大写字母开头，而 HTML 标签则必须是小写字母。`<MyButton />` 是以大写字母开头的

# 使用 JSX 编写标签 
JSX 比 HTML 更加严格。必须闭合标签，如 <br />。组件也不能返回多个 JSX 标签。必须将它们包裹到一个共享的父级中，比如 <div>...</div> 或使用空的 <>...</> 包裹
```jsx
function AboutPage() {
  return (
    <>
      <h1>About</h1>
      <p>Hello there.<br />How do you do?</p>
    </>
  );
}
```

# 显示数据
```jsx
return (
  <h1>
    {user.name}
  </h1>
);
```

复杂的表达式
```jsx
const user = {
  name: 'Hedy Lamarr',
  imageUrl: 'https://i.imgur.com/yXOvdOSs.jpg',
  imageSize: 90,
};

export default function Profile() {
  return (
    <>
      <h1>{user.name}</h1>
      <img
        className="avatar"
        src={user.imageUrl}
        alt={'Photo of ' + user.name}
        style={{
          width: user.imageSize,
          height: user.imageSize
        }}
      />
    </>
  );
}
// style={{}} 并不是一个特殊的语法，而是 style={ } JSX 大括号内的一个普通 {} 对象。当你的样式依赖于 JavaScript 变量时，你可以使用 style 属性
```

条件渲染 
```jsx
let content;
if (isLoggedIn) {
  content = <AdminPanel />;
} else {
  content = <LoginForm />;
}
return (
  <div>
    {content}
  </div>
);
```

```jsx
<div>
  {isLoggedIn ? (
    <AdminPanel />
  ) : (
    <LoginForm />
  )}
</div>
```
```jsx
<div>
  {isLoggedIn && <AdminPanel />}
</div>
```

渲染列表 
```jsx
const products = [
  { title: 'Cabbage', id: 1 },
  { title: 'Garlic', id: 2 },
  { title: 'Apple', id: 3 },
];

const listItems = products.map(product =>
    <li key={product.id}>
        {product.title}
    </li>
);

return (
    <ul>{listItems}</ul>
);
```

```jsx
const products = [
  { title: 'Cabbage', isFruit: false, id: 1 },
  { title: 'Garlic', isFruit: false, id: 2 },
  { title: 'Apple', isFruit: true, id: 3 },
];

export default function ShoppingList() {
  const listItems = products.map(product =>
    <li
      key={product.id}
      style={{
        color: product.isFruit ? 'magenta' : 'darkgreen'
      }}
    >
      {product.title}
    </li>
  );

  return (
    <ul>{listItems}</ul>
  );
}
```

响应事件
```jsx
function MyButton() {
  function handleClick() {
    alert('You clicked me!');
  }

  return (
    <button onClick={handleClick}>
      Click me
    </button>
  );
}
// 注意，onClick={handleClick} 的结尾没有小括号！不要 调用 事件处理函数：你只需 把函数传递给事件 即可。当用户点击按钮时 React 会调用你传递的事件处理函数.
```

更新界面
```jsx
import { useState } from 'react';
function MyButton() {
    const [count, setCount] = useState(0); //从 useState 中获得两样东西：当前的 state（count），以及用于更新它的函数（setCount）
}
```
```jsx
function MyButton() {
  const [count, setCount] = useState(0);

  function handleClick() {
    setCount(count + 1);
  }

  return (
    <button onClick={handleClick}>
      Clicked {count} times
    </button>
  );
}
```

```jsx
import { useState } from 'react';

export default function MyApp() {
  return (
    <div>
      <h1>Counters that update separately</h1>
      <MyButton />
      <MyButton /> 
    </div>
  );
} //每个组件都会拥有自己的 state

function MyButton() {
  const [count, setCount] = useState(0);

  function handleClick() {
    setCount(count + 1);
  }

  return (
    <button onClick={handleClick}>
      Clicked {count} times
    </button>
  );
}
```

# 使用 Hook 
以 use 开头的函数被称为 Hook。useState 是 React 提供的一个内置 Hook.

# 组件间共享数据
```jsx
export default function MyApp() {
    const [count, setCount] = useState(0);

    function handleClick() {
        setCount(count + 1);
    }

    return (
        <div>
            <h1>Counters that update together</h1>
            <MyButton count={count} onClick={handleClick} />
            <MyButton count={count} onClick={handleClick} />
        </div>
    );
}

function MyButton({ count, onClick }) {
    return (
        <button onClick={onClick}>
            Clicked {count} times
        </button>
    );
}
```

```jsx
import { useState } from 'react';

export default function MyApp() {
  const [count, setCount] = useState(0);

  function handleClick() {
    setCount(count + 1);
  }

  return (
    <div>
      <h1>Counters that update together</h1>
      <MyButton count={count} onClick={handleClick} />
      <MyButton count={count} onClick={handleClick} />
    </div>
  );
}

function MyButton({ count, onClick }) {
  return (
    <button onClick={onClick}>
      Clicked {count} times
    </button>
  );
}
```

React 组件必须返回单个 JSX 元素，不能像两个按钮那样返回多个相邻的 JSX 元素。要解决此问题，可以使用 Fragment（<> 与 </>）包裹多个相邻的 JSX 元素