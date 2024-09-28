package com.deakin;

import com.deakin.dao.StudentRepository;
import com.deakin.entity.Student;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cache.annotation.EnableCaching;
import org.springframework.data.redis.core.RedisTemplate;
import org.springframework.jdbc.core.BatchPreparedStatementSetter;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.util.StopWatch;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.util.Date;
import java.util.LinkedList;
import java.util.List;
import java.util.Random;

@SpringBootApplication
@EnableCaching
@RestController
public class BootApplication {
    public static void main(String[] args) {
        SpringApplication.run(BootApplication.class, args);
    }

    @Autowired
    private RedisTemplate<String, Object> redisTemplate;
    @Autowired
    private JdbcTemplate jdbcTemplate;
    @Autowired
    private StudentRepository studentRepository;

    @GetMapping
    public void getData(String param) {
        StopWatch stopWatch = new StopWatch();
        stopWatch.start();
        int index = new Random().nextInt(10000000);
        System.out.println("get index = " + index + ", param = " + param);
        if ("mysql".equals(param)) {
            Student student = studentRepository.findByFirstName("test first name-"+index);
            System.out.println("data from MySQL, student = " + student);
        } else if ("redis".equals(param)) {
            int page = index / 10000;
            int position = index % 10000;
            List<Student> students = (List<Student>) redisTemplate.opsForList().index("students", 1000 - (long) page - 1);
            System.out.println("data from Redis, student = " + students.get(position));
        }
        stopWatch.stop();
        System.out.println("time consume: " + stopWatch.getTotalTimeMillis()  + " milli seconds");
    }

    //    @GetMapping
    public void insertRecord(String param) throws InterruptedException {
        StopWatch stopWatch = new StopWatch();
        stopWatch.start();
        if ("mysql".equals(param)) {
            System.out.println("current time: " + new Date());
            System.out.println("start 10000000 data insert into Mysql");
            List<Student> students = new LinkedList<>();
            String sql = "insert into students(first_name,surname) values(?,?)";
            for (int i = 0; i < 10000000; i++) {
                Student student = new Student(i);
                students.add(student);
                if (students.size() >= 10000) {
                    extracted(sql, students);
                    students.clear();
                }
            }

            if (!students.isEmpty()) {
                extracted(sql, students);
                students.clear();
            }
        } else if ("redis".equals(param)) {
            System.out.println("current time: " + new Date());
            System.out.println("start 10000000 data insert into Redis");
            List<Student> students = new LinkedList<>();
            for (int i = 0; i < 10000000; i++) {
                Student student = new Student(i);
                students.add(student);
                if (students.size() >= 10000) {
                    redisTemplate.opsForList().leftPushAll("students", students);
                    students.clear();
                }
            }

            if (!students.isEmpty()) {
                redisTemplate.opsForList().leftPushAll("students", students);
                students.clear();
            }
        }
        stopWatch.stop();
        System.out.println("time consume: " + stopWatch.getTotalTimeMillis() / 1000 + " seconds");
    }

    private void extracted(String sql, List<Student> students) {
        jdbcTemplate.batchUpdate(sql, new BatchPreparedStatementSetter() {

            @Override
            public void setValues(PreparedStatement ps, int i) throws SQLException {
                ps.setString(1, students.get(i).getFirstName());
                ps.setString(2, students.get(i).getSurname());
            }

            @Override
            public int getBatchSize() {
                return students.size();
            }
        });
    }
}