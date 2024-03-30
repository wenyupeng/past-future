package slice_test

import "testing"

func TestSliceInit(t *testing.T) {
	var s0 []int
	t.Log(len(s0), cap(s0))
	s0 = append(s0, 1)
	t.Log(len(s0), cap(s0))

	s1 := []int{1, 2, 3, 4}
	t.Log(len(s1), cap(s1))

	s2 := make([]int, 3, 5) // make(type,len,capacity) len: 可访问的元素长度，capacity: 数组容量
	t.Log(len(s2), cap(s2))
	//t.Log(s2[0], s2[1], s2[2], s2[3]) // 数组越界
	t.Log(s2[0], s2[1], s2[2])
	s2 = append(s2, 1)
	t.Log(s2[0], s2[1], s2[2], s2[3])
	t.Log(len(s2), cap(s2))
}

func TestSliceGrowing(t *testing.T) {
	s := []int{}
	for i := 0; i < 10; i++ {
		s = append(s, i) // 当slice扩容时，会把原数据拷贝到新的slice下，返回新的slice地址
		t.Log(len(s), cap(s))
	}
}

func TestSliceShareMemory(t *testing.T) {
	year := []string{"Jan", "Feb", ",Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"}
	Q2 := year[3:6] // slice会从起始位置一直记录到终止位置
	t.Log(Q2, len(Q2), cap(Q2))
	t.Log(Q2)
	summer := year[5:8]
	t.Log(summer, len(summer), cap(summer))
	t.Log(summer)
	summer[0] = "Unknown"
	t.Log(Q2)
	t.Log(year)
}

func TestSliceCompare(t *testing.T) {
	a := [4]int{1, 2, 3, 4}
	b := [4]int{1, 2, 3, 4}
	//c := []int{1, 2, 3, 4}
	//d := []int{1, 2, 3, 4}
	if a == b {
		t.Log("equal")
	}

	//if c == d { //slice can only be compared to nil
	//	t.Log("equal")
	//}
}
