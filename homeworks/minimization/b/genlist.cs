public class genlist<T> {
	public T[] data;
	public int size = 0;
	public int capacity = 8;
	
	public genlist() {
		data = new T[capacity];
	}
	
	public void push(T item) {
		if (size == capacity) {
			capacity *= 2;
			T[] newdata = new T[capacity];
			for (int i=0; i<size; i++) {
				newdata[i] = data[i];
			}
			data = newdata;
		}
		data[size] = item;
		size++;
	}

	public void Remove(int i) {
		if (size - 1 < capacity / 2) {
			capacity /= 2;
		}
		T[] newdata = new T[capacity];
		for (int j=0; j<i; j++) {
			newdata[j] = data[j];
		}
		for (int j=i; j<size - 1; j++) {
			newdata[j] = data[j+1];
		}
		data = newdata;
		size--;
	}
}
