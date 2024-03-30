package array_test

import "testing"

func TestArrayInit(t *testing.T) {
	var arr [3]int                  // 声明
	arr1 := [4]int{1, 2, 3, 4}      //声明并初始化
	arr3 := [...]int{1, 2, 3, 4, 5} //声明并初始化，自动识别数组长度
	arr1[1] = 5
	t.Log(arr[1], arr[2])
	t.Log(arr1, arr3)
}

func TestArrayTravel(t *testing.T) {
	arr3 := [...]int{1, 3, 4, 5}
	for i := 0; i < len(arr3); i++ {
		t.Log(arr3[i])
	}

	for idx, e := range arr3 {
		t.Log(idx, e)
	}

	for _, e := range arr3 { //使用_占位，使得通过静态编译
		t.Log(e)
	}
}

func TestArraySection(t *testing.T) {
	arr3 := [...]int{1, 2, 3, 4, 5}
	arr3_sec := arr3[:]
	t.Log(arr3_sec)
}
